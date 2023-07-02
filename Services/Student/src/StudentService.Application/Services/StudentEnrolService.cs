using AutoMapper;
using StudentService.Application.Common.Exceptions;
using StudentService.Application.Interfaces.Repositories;
using StudentService.Application.Interfaces.Services;
using StudentService.Application.Models.DTOs;


namespace StudentService.Application.Services
{
    public class StudentEnrolService : IStudentEnrolService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentEnrolService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<EnrolmentDTO> CourseOfferingEnrolment(string studentId, int courseOfferingId)
        {
            throw new NotImplementedException();
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

        public Task<EnrolmentDTO> InitialCourseEnrolment(string studentId, int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EnrolmentDTO>> RegisterStudent(OfferDTO offer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RejectOffer(OfferDTO offer)
        {
            throw new NotImplementedException();
        }
    }
}
