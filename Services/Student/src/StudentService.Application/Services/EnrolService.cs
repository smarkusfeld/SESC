using AutoMapper;
using StudentService.Application.Common.Exceptions;
using StudentService.Application.Interfaces.Repositories;
using StudentService.Application.Interfaces.Services;
using StudentService.Application.Models.DTOs;
using StudentService.Domain.Entities;
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

        public async Task<EnrolmentConfirmationDTO> CourseEnrolment(string studentId, int courseOfferingId)
        {
            //check student account
            var account = await _unitOfWork.Students.GetAsync(studentId)
                ?? throw new KeyNotFoundException($"No Account Associated with Student {studentId}");
            //check course offering account
            var course = await _unitOfWork.CourseOfferings.GetAsync(courseOfferingId)
                ?? throw new KeyNotFoundException("Course Not Found");
            var courseEnrolment = new Enrolment
            {
                StudentId = studentId,
                CourseOfferingId = courseOfferingId,
            };
            var enrol = await _unitOfWork.CourseEnrolments.AddAsync(courseEnrolment);
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
                Amount = enrolment.Tutition,
                StudentID = enrolment.StudentId,
                Reference = enrolment.CourseOffering.Name
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
        private async Task<CourseOffering> FirstRegistration(string studentId, int courseId)
        {
            // get first course
            var courseOfferings = await _unitOfWork.CourseOfferings.GetAllWhereAsync(x => x.CourseId == courseId);
            var firstCourse = courseOfferings.Where(x => x.Requirements.Count == 0 || x.Requirements == null).OrderBy(x => x.Qualification.Level).FirstOrDefault();

            //create registration
            var reg = new CourseRegistration()
            {
                StudentId = studentId,
                CourseId = courseId,
                RegistrationDate = DateTime.Now,
            };
            var regResult = await _unitOfWork.Enrolments.AddAsync(reg);
           
            if (regResult != null)
            {
                var save = await _unitOfWork.Save();
               if(save > 0)
                {
                    var result = await _unitOfWork.Transcripts.AddAsync(new(regResult.Student, regResult.Course));
                  
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

     
        public Task<string> GetEligiableCourseOffering(string studentId, int courseOfferingId)
        {
            throw new NotImplementedException();
        }
    }
}
