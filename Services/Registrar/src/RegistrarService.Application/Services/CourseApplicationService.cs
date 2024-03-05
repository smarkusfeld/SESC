using AutoMapper;
using RegistrarService.Application.Interfaces.Repositories;
using RegistrarService.Application.Interfaces.Services;
using RegistrarService.Application.Models.DTOs.InputModels;
using RegistrarService.Application.Models.DTOs.ReponseModels;
using RegistrarService.Application.Common.Exceptions;
using RegistrarService.Domain.Common.Enums;

namespace RegistrarService.Application.Services
{
    public class CourseApplicationService : ICourseApplicantionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Task<CourseApplicationDTO> AddApplication(NewApplicationDTO Applicantion)
        {
            //validate course code

            //application validation

            //add new application
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CourseApplicationDTO>> GetAllApplications()
        {
            var result = await _unitOfWork.CourseApplications.GetAllAsync();
            if (result != null)
            {
                return _mapper.Map<IEnumerable<CourseApplicationDTO>>(result);
            }
            return Enumerable.Empty<CourseApplicationDTO>();
        }

        public async Task<IEnumerable<CourseApplicationDTO>> GetAllApplications(int applicantId)
        {
            //check applicant id
            var applicant = await _unitOfWork.Applicants.GetAsync(applicantId)
                ?? throw new KeyNotFoundException ($"No applicant associated with applicant id: {applicantId}");

            //get applicant accounts
            var result = await _unitOfWork.CourseApplications.GetAllWhereAsync(x => x.ApplicantId == applicantId);
            if (result != null)
            {
                return _mapper.Map<IEnumerable<CourseApplicationDTO>>(result);
            }
            return Enumerable.Empty<CourseApplicationDTO>();
        }

        public async Task<IEnumerable<CourseApplicationDTO>> GetAllApplicationsbyCourse(string courseCode)
        {
            //check course code id
            var applicant = await _unitOfWork.Courses.GetAsync(courseCode)
                ?? throw new KeyNotFoundException($"Course code: {courseCode} not found");
            //get applications for couse code
            var result = await _unitOfWork.CourseApplications.GetAllWhereAsync(x => x.CourseCode == courseCode);
            if (result != null)
            {
                return _mapper.Map<IEnumerable<CourseApplicationDTO>>(result);
            }
            return Enumerable.Empty<CourseApplicationDTO>();
        }

        public async Task<IEnumerable<CourseApplicationDTO>> GetAllApplicationsbyStatus(string appStatus)
        {
            if (Enum.TryParse(appStatus, true, out ApplicationStatus search))
            {
                var result = await _unitOfWork.CourseApplications.GetAllWhereAsync(x => x.Status == search);
                if (result != null)
                {
                    return _mapper.Map<IEnumerable<CourseApplicationDTO>>(result);
                }
                return Enumerable.Empty<CourseApplicationDTO>();
            }
            throw new NotFoundException($"Status: {appStatus} not found");
        }

        public async Task<CourseApplicationDTO> GetApplication(int ApplicationId)
        {
            var result = await _unitOfWork.CourseApplications.GetAsync(ApplicationId)
                ?? throw new KeyNotFoundException($"No application found for applicantion id: {ApplicationId}");
            return _mapper.Map<CourseApplicationDTO>(result);
        }

        public async Task<CourseApplicationDTO> UpdateApplication(ApplicationDTO Applicantion)
        {
            //validate application id

            //application validation

            //add new application
            throw new NotImplementedException();
        }

        public async Task<CourseApplicationDTO> Accept(int ApplicationId)
        {
            //check application Id
            var application = await _unitOfWork.CourseApplications.GetAsync(ApplicationId)
                ?? throw new KeyNotFoundException($"No application found for applicantion id: {ApplicationId}");

            if(application.Status == ApplicationStatus.Offer)
            {
                application.Status = ApplicationStatus.Accepted;
                var result = await _unitOfWork.CourseApplications.UpdateAsync(application)
                    ?? throw new MySQLException("Could not update application");
                return _mapper.Map<CourseApplicationDTO>(result);
            }
            throw new BadRequestException("Cannot accept until offer issued");
        }

        public async Task<CourseApplicationDTO> Decline(int ApplicationId)
        {
            //check application Id
            var application = await _unitOfWork.CourseApplications.GetAsync(ApplicationId)
                ?? throw new KeyNotFoundException($"No application found for applicantion id: {ApplicationId}");

            if (application.Status == ApplicationStatus.Offer || application.Status == ApplicationStatus.ConditionalOffer)
            {
                application.Status = ApplicationStatus.Declined;
                var result = await _unitOfWork.CourseApplications.UpdateAsync(application)
                    ?? throw new MySQLException("Could not update application");
                return _mapper.Map<CourseApplicationDTO>(result);
            }
            throw new BadRequestException("Cannot decline until offer issued");
        }

        public async Task<CourseApplicationDTO> Withdraw(int ApplicationId)
        {
            //check application Id
            var application = await _unitOfWork.CourseApplications.GetAsync(ApplicationId)
                ?? throw new KeyNotFoundException($"No application found for applicantion id: {ApplicationId}");

            application.Status = ApplicationStatus.Withdrawn;
            var result = await _unitOfWork.CourseApplications.UpdateAsync(application)
                ?? throw new MySQLException("Could not update application");
            return _mapper.Map<CourseApplicationDTO>(result);
        }
    }
}
