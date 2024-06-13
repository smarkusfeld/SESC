using AutoMapper;
using RegistrarService.Application.Common.Exceptions;
using RegistrarService.Application.Interfaces.Repositories;
using RegistrarService.Application.Interfaces.Services;
using RegistrarService.Application.Models.DTOs.InputModels;
using RegistrarService.Application.Models.DTOs.ReponseModels;
using RegistrarService.Domain.Common.Enums;
using RegistrarService.Domain.Common.Enums.StudentService.Domain.Common.Enums;
using RegistrarService.Domain.Entities;

namespace RegistrarService.Application.Services
{
    public class EnrolService : IEnrolService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EnrolService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EnrolmentDTO> Enrol(int courseLevel, UpdateStudentDTO student)
        {            

            //update student account
            var studentUpdate = await UpdateStudentAccount(student);

            var enrolment = await _unitOfWork.Enrolments.AddAsync(new Enrolment(studentUpdate.StudentId, courseLevel))
           ?? throw new MySQLException($"Unable to complete enrolment");
            return _mapper.Map<EnrolmentDTO>(enrolment);

        }
        public async Task<EnrolmentDTO> Enrol(int courseLevel, int studentId)
        {

            var enrolment = await _unitOfWork.Enrolments.AddAsync(new Enrolment(studentId, courseLevel))
           ?? throw new MySQLException($"Unable to complete enrolment");
            return _mapper.Map<EnrolmentDTO>(enrolment);

        }


        public async Task<EnrolmentDTO> Enrol(int courseLevel, NewStudentDTO student)
        {
            
            var newStudent = await AddStudentAccount(student);
            var enrolment = await _unitOfWork.Enrolments.AddAsync(new Enrolment(newStudent.StudentId, courseLevel))
                ?? throw new MySQLException($"Unable to complete enrolment");
            return _mapper.Map<EnrolmentDTO>(enrolment);
                          
        }

        public async Task<IEnumerable<EnrolmentDTO>> GetAllEnrolments(int studentId)
        {
            //get student account
            var check = await _unitOfWork.Students.GetAsync(studentId)
               ?? throw new KeyNotFoundException($"No Account Associated with Student {studentId}");

            var result = await _unitOfWork.Enrolments.GetAllWhereAsync(x=>x.StudentId==studentId);
            if (result != null)
            {
                return _mapper.Map<IEnumerable<EnrolmentDTO>>(result);
            }
            return Enumerable.Empty<EnrolmentDTO>();
        }

        public async Task<int> GetEligibleCourseLevel(string courseCode, int studentId)
        {
            //check course code 
            courseCode = courseCode.Normalize();
            var course = await _unitOfWork.Courses.GetAsync(courseCode)
                ?? throw new KeyNotFoundException($"Course code: {courseCode} not found");

            //get student account
            var account = await _unitOfWork.Students.GetAsync(studentId)
               ?? throw new KeyNotFoundException($"No Account Associated with Student {studentId}");

            var results = await _unitOfWork.Results.GetAllWhereAsync(x => x.StudentId == studentId && x.CourseLevel.CourseCode.Equals(courseCode))
                ?? throw new BadRequestException($"Check student course code");

            var lastResult = results.OrderByDescending(d => d.ProgressDate).First();
            switch (lastResult.ProgressDecision)
            {
                case ProgressDecision.pass_proceed:
                    int newLevel = lastResult.CourseLevel.QualificationLevel + 1;
                    return lastResult.CourseLevel.Course.CourseLevels.Where(x => x.QualificationLevel == newLevel).First().CourseLevelId;
                case ProgressDecision.reassesment:
                case ProgressDecision.deffered:
                case ProgressDecision.failed_repeat:
                    return lastResult.CourseLevel.CourseLevelId;
                case ProgressDecision.contained_award:
                case ProgressDecision.awarded:
                    throw new BadRequestException($"Student {studentId} has already completed this course");
                default:
                    throw new BadRequestException($"Student {studentId} not elgible to enrol in course at this time. Progression Status {lastResult.ProgressDecision}");

            }

        }

        /// <summary>
        /// Get first course level for new students
        /// </summary>
        /// <param name="courseCode"></param>
        /// <param name="applicantId"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        /// <exception cref="MySQLException"></exception>
        public async Task<int> GetFirstCourseLevel(string courseCode, int applicantId)
        {
            //check course code 
            courseCode = courseCode.Normalize();
            var course = await _unitOfWork.Courses.GetAsync(courseCode)
                ?? throw new KeyNotFoundException($"Course code: {courseCode} not found");

            //check applicant id
            var applicant = await _unitOfWork.Applicants.GetByAsync(x => x.ApplicantId == applicantId)
                ?? throw new KeyNotFoundException($"Applicant Id: {applicantId} not found");

            var applicantion = await _unitOfWork.Applications.GetByAsync(x=>x.ApplicantId == applicantId && x.CourseCode.Equals(courseCode))
                ?? throw new BadRequestException($"No applicants for course {courseCode} found for applicant {applicantId}. Please check course code ");

            switch (applicantion.Status)
            {
                case ApplicationStatus.Accepted:
                    //get first course level
                    var level = applicantion.Course.CourseLevels.OrderBy(x => x.QualificationLevel).ToList().First()
                        ?? throw new MySQLException($"No Course Levels found for course {courseCode}");
                    return level.CourseLevelId;
                case ApplicationStatus.ConditionalOffer:
                case ApplicationStatus.Offer:
                    throw new BadRequestException($"Applicant {applicantId} must meet offer conditions and/or accept offer prior to enrolment");
                case ApplicationStatus.Declined:
                    throw new BadRequestException($"Applicant {applicantId} has declined or withdrawn their application for course {courseCode}");
                default:
                    throw new BadRequestException($"Applicant {applicantId} is unable to enrol due to applicantion status: {applicantion.Status}");
                    
            }           
            
        }
        /// <summary>
        /// UpdateStudentAccount
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="MySQLException"></exception>
        private async Task<StudentAccountDTO> UpdateStudentAccount(UpdateStudentDTO student)
        {
            var update = _mapper.Map<Student>(student);
            var result =  _unitOfWork.Students.Update(update)
                ?? throw new MySQLException("Could not update student account");
            return _mapper.Map<StudentAccountDTO>(result);
        }

        /// <summary>
        /// Create New Student Account
        /// </summary>
        /// <param name="studentDTO"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        private async Task<StudentAccountDTO> AddStudentAccount(NewStudentDTO studentDTO)
        {
            string normalizedEmail = studentDTO.Email.Normalize().ToUpperInvariant();
            var check = await _unitOfWork.Students.GetByAsync(x => x.AlternateEmail.Normalize().ToUpperInvariant().Equals(normalizedEmail));
            if (check != null) { throw new BadRequestException($"Student already exists for {studentDTO.Email}"); }

            var student = _mapper.Map<Student>(studentDTO);
            student.StudentEmail = await CreateStudentEmail(studentDTO.FirstName, studentDTO.Surname);

            var newStudent = await _unitOfWork.Students.AddAsync(student);
            if (await _unitOfWork.Save() < 0)
            {
                throw new BadRequestException();
            }
            return _mapper.Map<StudentAccountDTO>(newStudent);
        }

        /// <summary>
        /// Create Student Email for new students
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="surname"></param>
        /// <returns></returns>
        private async Task<string> CreateStudentEmail(string firstname, string surname)
        {
            string emailHeader = surname + '.' + firstname;
            string emailDomain = "@student.school.ac.uk";
            int i = 1;
            while (true)
            {
                string email = emailHeader + emailDomain;
                string normalizedEmail = email;
                var check = await _unitOfWork.Students.GetByAsync(x => x.AlternateEmail.Normalize().ToUpperInvariant().Equals(normalizedEmail));
                if (check == null)
                {
                    return email;
                }
                emailHeader += i;
                i++;
            }
        }
    }
}
