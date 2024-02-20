using AutoMapper;
using RegistrarService.Application.Common.Exceptions;
using RegistrarService.Application.Interfaces.Repositories;
using RegistrarService.Application.Interfaces.Services;
using RegistrarService.Application.Models.DTOs.InputModels;
using RegistrarService.Application.Models.DTOs.ReponseModels;
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

        public async Task<TuitionInvoiceDTO> Enrol(string studentId)
        {
            //check student account
            var account = await _unitOfWork.Accounts.GetAsync(studentId)
                ?? throw new KeyNotFoundException($"No Account Associated with Student {studentId}");
            var course = account.Transcript.Course ?? throw new BadRequestException("Student not registered for course");

            //get eligible course level
            var eligibileLevel = await GetEligiableCourseLevel(studentId, course) ?? throw new BadRequestException("Student not eligible to register for any courses in current program");

            //get session
            var session = GetOpenSession(eligibileLevel, account);
            if (eligibileLevel == null) { throw new BadRequestException("No open sessions for course level"); }
            //enrol student
            account.Enrol(session.Id);

            //add invoice
            var enrolment = await _unitOfWork.Accounts.CompleteEnrolment(account);
            if (enrolment != null)
            {
               
                var save = await _unitOfWork.Save();
                return save > 0 ? CreateInvoice(studentId, session) : throw new MySQLException();
            }
            throw new MySQLException();
        }

        public TuitionInvoiceDTO CreateInvoice(string studentId, Session session)
        {
            return new TuitionInvoiceDTO()
                {
                    StudentID = studentId,
                    Amount = session.CourseLevel.TuitionFee,
                    SessionId = session.Id,
                    CourseLevelId = session.CourseLevel.Id,
                    CourseLevelName = session.CourseLevel.Name,
                    CourseCode = session.CourseLevel.Course.CourseCode
                };
        }

       
        public async Task<IEnumerable<EnrolmentDTO>> GetAllEnrolments(string studentId)
        {
            //check student account
            var account = await _unitOfWork.Accounts.GetAsync(studentId)
                ?? throw new KeyNotFoundException($"No Account Associated with Student {studentId}");

            var enrolments = account.Enrolments.ToArray();
            if (enrolments != null)
            {
                return _mapper.Map<EnrolmentDTO[]>(enrolments);
            }          
            throw new NotFoundException($"No enrolment records found for {studentId}");
        }
       

        public async Task<TuitionInvoiceDTO> CourseRegistration(CourseRegistrationDTO registration)
        {
            //vaidate course ID
            var course = await _unitOfWork.Courses.GetByAsync(x=>x.CourseCode == registration.CourseCode)
                ?? throw new NotFoundException("No active courses with course code");
            //validate student id
            var student = await _unitOfWork.Accounts.GetAsync(registration.StudentId)
                ?? throw new KeyNotFoundException($"No Account Associated with Student {registration.StudentId}");
            // TODO add validation for course ID
            return await Register(student, course, registration.StartYear)
                ?? throw new BadRequestException("Registration Could Not Be Completed");
           
        }

        public async Task<TuitionInvoiceDTO> Register(Student account, Course course, int year)
        {
            
            //register in course
            if (!account.Register(course.Id))
            {
                throw new BadRequestException("Student already registered in course");
            }
            account.Transcript.AddUpdateCourse(course.Id);
            //enrol in first course
            var level = course.GetFirstCourseLevel();
            var session = level.ActiveSessions.Where(x => x.AcademicYear.StartYear == year && x.EnrolmentOpen).First() 
                ?? throw new BadRequestException("No Open Sessions for Course");
            if (account.Enrol(session.Id))
            {
                var update = await _unitOfWork.Accounts.CompleteRegistration(account);

                var save = await _unitOfWork.Save();

                return save > 0 ? CreateInvoice(account.StudentId, session) : throw new MySQLException();
            }
            throw new BadRequestException("No available source sessions");
        }

        public async Task<CourseLevel?> GetEligiableCourseLevel(string studentId, Course course)
        {
            //Get student
            var account = await _unitOfWork.Accounts.GetAsync(studentId) ?? throw new BadRequestException("Invalid Student ID");

            //get next course level
            var result = account.Transcript.Results.OrderByDescending(x => x.ProgressDate).First();
            var currentLevel = result.Session.CourseLevel;
            return result.ProgressDecision switch
            {
                ProgressDecision.pass_proceed => course.CourseLevels.Where(x => x.QualificationLevel > currentLevel.QualificationLevel).OrderBy(x => x.QualificationLevel).First(),
                ProgressDecision.failed_repeat or ProgressDecision.reassesment => result.Session.CourseLevel,
                _ => null,
            };
        }

        public async Task<bool> CheckCourseRegistration(string studentId, int courseId)
        {            
            var account = await _unitOfWork.Accounts.GetAsync(studentId);
            return account.Registrations.Any(x=>x.SessionId == courseId);
        }

        public Session GetOpenSession(CourseLevel courseLevel, Student account)
        {
            var year = account.Transcript.Results.OrderByDescending(x => x.ProgressDate).First().AcademicYear.StartYear;
            var nextyear = year + 1;
            return courseLevel.ActiveSessions.Where(x => x.AcademicYear.StartYear == nextyear && x.EnrolmentOpen).First();
        }




    }
}
