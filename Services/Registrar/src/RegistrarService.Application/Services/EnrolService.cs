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


        public async Task<EnrolmentDTO> Enrol(string courseCode, int studentId)
        {
            var courseLevel = await GetEligibleCourseLevel(courseCode, studentId);
            if (courseLevel != 0)
            {
                var enrolment = await _unitOfWork.Enrolments.AddAsync(new Enrolment(studentId, courseLevel));
                if (await _unitOfWork.Save() < 0)
                {
                    throw new BadRequestException();
                }
                return _mapper.Map<EnrolmentDTO>(enrolment);
            }
            else
            {
                throw new BadRequestException("Unable to enrol student in course");
            }

        }

        public async Task<EnrolmentDTO> FirstEnrol(string courseCode, int applicantId)
        {
            //check course code 
            courseCode = courseCode.Normalize();
            var course = await _unitOfWork.Courses.GetAsync(courseCode)
                ?? throw new KeyNotFoundException($"Course code: {courseCode} not found");

            //check applicant id
            var applicant = await _unitOfWork.Applicants.GetByAsync(x => x.ApplicantId == applicantId)
                ?? throw new KeyNotFoundException($"Applicant Id: {applicantId} not found");

            //check application
            var application = await _unitOfWork.Applications.GetByAsync(x => x.ApplicantId == applicantId && x.CourseCode.Equals(courseCode))
                ?? throw new BadRequestException($"No applicants for course {courseCode} found for applicant {applicantId}. Please check course code ");

            if (!CheckApplicationStatus(application))
            {
                throw new BadRequestException("Unable to enrol applicant in course");
            }
            var courselevel = course.CourseLevels.OrderByDescending(x => x.QualificationLevel).ToList().First()
                ?? throw new BadRequestException("No Course Levels Available for Enrolment");

            var newStudent = await AddStudentAccount(applicant);

            var enrolment = await _unitOfWork.Enrolments.AddAsync(new Enrolment(newStudent.StudentId, courselevel.CourseLevelId));
            if (await _unitOfWork.Save() < 0)
            {
                throw new BadRequestException();
            }
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

        private async Task<int> GetEligibleCourseLevel(string courseCode, int studentId)
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

            var lastResult = results.OrderBy(d => d.ProgressDate).First();
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
        /// Check Application Status
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        private bool CheckApplicationStatus(CourseApplication application)
        {

            switch (application.Status)
            {
                case ApplicationStatus.Accepted:
                    return true;
                case ApplicationStatus.ConditionalOffer:
                case ApplicationStatus.Offer:
                    throw new BadRequestException($"Applicant {application.ApplicantId} must meet offer conditions and/or accept offer prior to enrolment");
                case ApplicationStatus.Declined:
                    throw new BadRequestException($"Applicant {application.ApplicantId}  has declined or withdrawn their application for course {application.CourseCode}");
                default:
                    throw new BadRequestException($"Applicant {application.ApplicantId}  is unable to enrol due to applicantion status: {application.Status}");

            }

        }
       


        /// <summary>
        /// Create New Student Account
        /// </summary>
        /// <param name="studentDTO"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        private async Task<StudentAccountDTO> AddStudentAccount(Applicant applicant)
        {
            var check = await _unitOfWork.Students.GetByAsync(x => x.AlternateEmail.Equals(applicant.Email));
            if (check != null) { throw new BadRequestException($"Student already exists for {applicant.Email}"); }

            var email = await CreateStudentEmail(applicant.FirstName, applicant.Surname);
            var student = new Student()
            {
                FirstName = applicant.FirstName,
                MiddleName = applicant.MiddleName,
                Surname = applicant.Surname,
                AlternateEmail = applicant.Email,
                StudentEmail = email,

            };

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
                var check = await _unitOfWork.Students.GetByAsync(x => x.AlternateEmail.Equals(email));
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
