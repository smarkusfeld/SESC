using AutoMapper;
using StudentService.Application.Common.Exceptions;
using StudentService.Application.Interfaces.Repositories;
using StudentService.Application.Interfaces.Services;
using StudentService.Application.Models.DTOs;
using StudentService.Application.Models.DTOs.InputModels;
using StudentService.Application.Models.DTOs.ReponseModels;
using StudentService.Domain.Common.Enums.StudentService.Domain.Common.Enums;
using StudentService.Domain.Entities;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

namespace StudentService.Application.Services
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

        public async Task<EnrolmentConfirmationDTO> CourseEnrolment(string studentId, int courseLevelId)
        {
            //check student account
            var account = await _unitOfWork.Students.GetAsync(studentId)
                ?? throw new KeyNotFoundException($"No Account Associated with Student {studentId}");
            //check course offering account
            var course = await _unitOfWork.CourseLevels.GetAsync(courseLevelId)
                ?? throw new KeyNotFoundException("Course Not Found");
            var courseEnrolment = new Enrolment
            {
                StudentId = studentId,
                CourseLevelId = courseLevelId,
            };
            var enrol = await _unitOfWork.Enrolments.AddAsync(courseEnrolment);
            if (enrol != null)
            {
               
                var save = await _unitOfWork.Save();
                var enrolDTO = _mapper.Map<EnrolmentDTO>(enrol);
                var invoiceDTO = CreateTutionInvoice(enrol);
                return save > 0 ? new EnrolmentConfirmationDTO(invoiceDTO, enrolDTO) : throw new BadRequestException();
            }
            throw new BadRequestException();
        }

        /// <summary>
        /// Create Tuition Invoice
        /// </summary>
        /// <param name="enrolment"></param>
        /// <returns></returns>
        private TuitionInvoiceDTO CreateTutionInvoice(Enrolment enrolment)
        {
            return new TuitionInvoiceDTO
            {
                Amount = enrolment.CourseLevel.TuitionFee,
                StudentID = enrolment.StudentId,
                Reference = enrolment.CourseLevel.Name
            };
        }

        public async Task<IEnumerable<EnrolmentDTO>> GetAllEnrolments(string studentId)
        {
            //check student account
            var account = await _unitOfWork.Students.GetAsync(studentId)
                ?? throw new KeyNotFoundException($"No Account Associated with Student {studentId}");

            var enrolments = account.Enrolments.ToArray();
            if (enrolments != null)
            {
                return _mapper.Map<EnrolmentDTO[]>(enrolments);
            }          
            throw new NotFoundException($"No enrolment records found for {studentId}");

        }
       

        public async Task<InitalRegistrationConfirmationDTO> RegisterNewStudent(StudentRegistrationDTO registration)
        {
            //vaidate course ID
            var course = await _unitOfWork.Courses.GetByAsync(x=>x.CourseCode == registration.CourseCode)
                ?? throw new NotFoundException("No active courses with course code");
            //create student account
            var student = await CreateStudentAccount(registration) ?? throw new BadRequestException("Student account could not be created");
            // TODO add validation for course ID
            var regResult = await FirstRegistration(student.StudentId, course.Id)
                ?? throw new BadRequestException("Registration Could Not Be Completed");
            // complete enrolment
            var enrolResult = await CourseEnrolment(student.StudentId, regResult.Id);
            var account = _mapper.Map<StudentDTO>(student);
            if(enrolResult != null)
            {
                return new InitalRegistrationConfirmationDTO(account, enrolResult);
            }
            
             throw new BadRequestException();

        }
        
        /// <summary>
        /// Complete first registration and create student transcript
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns>The Course Offering with the lowest level/requirements associated witht the course</returns>
        /// <exception cref="BadRequestException"></exception>
        private async Task<CourseLevel> FirstRegistration(string studentId, int courseId)
        {
            // get first course
            var courseLevels = await _unitOfWork.CourseLevels.GetAllWhereAsync(x => x.CourseId == courseId);
            var firstCourse = courseLevels.OrderBy(x => x.QualificationLevel).FirstOrDefault();

            //create registration
            var reg = new CourseRegistration()
            {
                StudentId = studentId,
                CourseId = courseId,
                RegistrationDate = DateTime.Now,
            };
            var regResult = await _unitOfWork.Registrations.AddAsync(reg);
           
            if (regResult != null)
            {
                var save = await _unitOfWork.Save();
               if(save > 0)
                {
                    var student = regResult.Student;
                    student.Transcript = new(regResult.Student, regResult.Course);
                    var result = await _unitOfWork.Students.UpdateAsync(student);
                  
                    return firstCourse;
                }

            }
            throw new BadRequestException();
        }
        
      
        /// <summary>
        /// Create New Student Account
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        private async Task<Student?> CreateStudentAccount(StudentRegistrationDTO registration)
        {
            var id = _unitOfWork.Students.GetNextStudentId();

            var student = new Student()
            {
                FirstName = registration.FirstName,
                Surname = registration.Surname,
                MiddleName = registration.MiddleName,
            };
            var account = await _unitOfWork.Students.AddAsync(student);
            if (account != null)
            {
                var save = await _unitOfWork.Save();
                return save > 0 ? account : null;
            }
            return null;

        }

     
        public async Task<int> GetEligiableCourseOffering(string studentId, string courseCode)
        {
            // check student registration
            var studentCourses = await _unitOfWork.Registrations
               .GetAllWhereAsync(x => x.StudentId == studentId && x.Course.CourseCode == courseCode)
               ?? throw new BadRequestException("Student Not Registered For Course");

            // get course offerings
            var courseLevels = await _unitOfWork.CourseLevels
                .GetAllWhereAsync(x => x.Course.CourseCode == courseCode)
                ?? throw new BadRequestException($"Could not find {courseCode}");

           //get highest qualification recieved
            var results = await _unitOfWork.StudentResults
                .GetAllWhereAsync(x=> x.Transcript.StudentId == studentId && x.CourseLevel.Course.CourseCode == courseCode && x.ProgressDecision == ProgressDecision.pass_proceed);

            var nextLevel = results.OrderByDescending(x => x.CourseLevel.QualificationLevel).Select(x=>x.CourseLevel.QualificationLevel).FirstOrDefault() + 1;
            
            // no qualifications have been awared select the lowest course offering with no requirements
            if (results==null || !results.Any())
            {
                return courseLevels
                    .OrderBy(x=>x.QualificationLevel)
                    .Select(x=>x.Id).First();
            }
            try
            {
                return courseLevels
                     .Where(x => x.QualificationLevel == nextLevel)
                     .Select(x => x.Id).First();
            }
            catch
            {
                throw new BadRequestException("Student Not Eligible To Register for Course");
            }

        }
    }
}
