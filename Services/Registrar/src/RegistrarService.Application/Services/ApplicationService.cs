
using AutoMapper;
using RegistrarService.Application.Interfaces.Repositories;
using RegistrarService.Application.Interfaces.Services;
using RegistrarService.Application.Models.DTOs.InputModels;
using RegistrarService.Application.Models.DTOs.ReponseModels;
using RegistrarService.Application.Common.Exceptions;
using RegistrarService.Domain.Common.Enums;
using RegistrarService.Domain.Entities;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace RegistrarService.Application.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApplicationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ApplicationDTO>> GetAllApplications()
        {
            var result = await _unitOfWork.Applications.GetAllAsync();
            if (result != null)
            {
                return _mapper.Map<IEnumerable<ApplicationDTO>>(result);
            }
            return Enumerable.Empty<ApplicationDTO>();
        }

        public async Task<IEnumerable<ApplicationDTO>> GetAllApplications(int applicantId)
        {
            //check applicant id
            var applicant = await _unitOfWork.Applicants.GetAsync(applicantId)
                ?? throw new KeyNotFoundException ($"No applicant associated with applicant id: {applicantId}");

            //get applicant accounts
            var result = await _unitOfWork.Applications.GetAllWhereAsync(x => x.ApplicantId == applicantId);
            if (result != null)
            {
                return _mapper.Map<IEnumerable<ApplicationDTO>>(result);
            }
            return Enumerable.Empty<ApplicationDTO>();
        }

        public async Task<IEnumerable<ApplicationDTO>> GetAllApplicationsbyCourse(string courseCode)
        {
            //check course code id
            var applicant = await _unitOfWork.Courses.GetAsync(courseCode)
                ?? throw new KeyNotFoundException($"Course code: {courseCode} not found");
            //get applications for couse code
            var result = await _unitOfWork.Applications.GetAllWhereAsync(x => x.CourseCode == courseCode);
            if (result != null)
            {
                return _mapper.Map<IEnumerable<ApplicationDTO>>(result);
            }
            return Enumerable.Empty<ApplicationDTO>();
        }

        public async Task<IEnumerable<ApplicationDTO>> GetAllApplicationsbyStatus(string appStatus)
        {
            if (Enum.TryParse(appStatus, true, out ApplicationStatus search))
            {
                var result = await _unitOfWork.Applications.GetAllWhereAsync(x => x.Status == search);
                if (result != null)
                {
                    return _mapper.Map<IEnumerable<ApplicationDTO>>(result);
                }
                return Enumerable.Empty<ApplicationDTO>();
            }
            throw new BadRequestException($"Invalid Application Status: {appStatus}");
        }

        public async Task<ApplicationDTO> GetApplication(int ApplicationId)
        {
            var result = await _unitOfWork.Applications.GetAsync(ApplicationId)
                ?? throw new KeyNotFoundException($"No application found for applicantion id: {ApplicationId}");
            return _mapper.Map<ApplicationDTO>(result);
        }

       

        public async Task<ApplicationDTO> Accept(int applicationId)
        {
            //check application Id
            var application = await _unitOfWork.Applications.GetAsync(applicationId)
                ?? throw new KeyNotFoundException($"No application found for applicantion id: {applicationId}");

            if(application.Status == ApplicationStatus.Offer)
            {
                application.Status = ApplicationStatus.Accepted;
                var result =  _unitOfWork.Applications.Update(application)
                    ?? throw new MySQLException("Could not update application");
                return _mapper.Map<ApplicationDTO>(application);
            }
            throw new BadRequestException("Cannot accept until offer issued");
        }

        public async Task<ApplicationDTO> Decline(int applicationId)
        {
            //check application Id
            var application = await _unitOfWork.Applications.GetAsync(applicationId)
                ?? throw new KeyNotFoundException($"No application found for applicantion id: {applicationId}");

            if (application.Status == ApplicationStatus.Offer || application.Status == ApplicationStatus.ConditionalOffer)
            {
                application.Status = ApplicationStatus.Declined;
                var result = _unitOfWork.Applications.Update(application)
                    ?? throw new MySQLException("Could not update application");
                return _mapper.Map<ApplicationDTO> (application);
            }
            throw new BadRequestException("Cannot decline until offer issued");
        }

        public async Task<ApplicationDTO> Withdraw(int applicationId)
        {
            //check application Id
            var application = await _unitOfWork.Applications.GetAsync(applicationId)
                ?? throw new KeyNotFoundException($"No application found for applicantion id: {applicationId}");

            application.Status = ApplicationStatus.Withdrawn;
            var result = _unitOfWork.Applications.Update(application)
                ?? throw new MySQLException("Could not update application");
            return _mapper.Map<ApplicationDTO>(application);
        }

        public async Task<ApplicationDTO> SubmitApplication(int applicationId)
        {
            //check application Id
            var application = await _unitOfWork.Applications.GetAsync(applicationId)
                ?? throw new KeyNotFoundException($"No application found for applicantion id: {applicationId}");

            application.Status = ApplicationStatus.Received;
            var result = _unitOfWork.Applications.Update(application)
                ?? throw new MySQLException("Could not update application");
            return _mapper.Map<ApplicationDTO>(application);


        }

        public async Task<ApplicationDTO> UpdateApplication(UpdateApplicationDTO inputModel)
        {
            //check application Id
            var application = await _unitOfWork.Applications.GetAsync(inputModel.ApplicationId)
                ?? throw new KeyNotFoundException($"No application found for applicantion id: {inputModel.ApplicationId}");
            application.Statement = inputModel.Statement;
            if (!Enum.TryParse(inputModel.Status, true, out ApplicationStatus status))
            {
                { throw new BadRequestException($"Invalid Application Status: {status}"); }
            }
            application.Status = status;
            var result = _unitOfWork.Applications.Update(application)
                ?? throw new MySQLException("Could not update application");
            return _mapper.Map<ApplicationDTO>(application);


        }
        public async Task<ApplicationDTO> SaveApplication(NewApplicationDTO inputModel)
        {
            //validate application id
            var applicant = await _unitOfWork.Applicants.GetAsync(inputModel.ApplicantId)
                ?? throw new KeyNotFoundException($"No applicant associated with applicant id: {inputModel.ApplicantId}");
            //check course code
            var course = await _unitOfWork.Courses.GetAsync(inputModel.CourseCode)
                ?? throw new KeyNotFoundException($"No course associated with course code: {inputModel.CourseCode}");

            //add application
            var application = new CourseApplication(inputModel.ApplicantId, inputModel.CourseCode);
            application.Statement = inputModel.Statement;
            application.Status = ApplicationStatus.InProgress;
            var addedApplication = await _unitOfWork.Applications.AddAsync(application);
            if (addedApplication != null)
            {
                var result = await _unitOfWork.Save();
                var dto = new ApplicationDTO
                {
                    ApplicationId = addedApplication.ApplicationId,
                    ApplicantId = addedApplication.ApplicantId,
                    CourseCode = course.CourseCode,
                    FirstName = applicant.FirstName,
                    Surname = applicant.Surname,
                    MiddleName = applicant.MiddleName,
                    Email = applicant.Email,
                    Address = _mapper.Map<AddressDTO>(applicant.Address),
                    Status = addedApplication.Status.ToString()

                };
                return result > 0 ? dto : throw new MySQLException();
            }
            throw new BadRequestException("Unable to create application.");


        }

        public async Task<ApplicationDTO> SaveApplication(int applicantId, string courseCode)
        {
            //validate application id
            var applicant = await _unitOfWork.Applicants.GetAsync(applicantId)
                ?? throw new KeyNotFoundException($"No applicant associated with applicant id: {applicantId}");
            //check course code
            var course = await _unitOfWork.Courses.GetAsync(courseCode)
                ?? throw new KeyNotFoundException($"No course associated with course code: {courseCode}");

            //add application
            var application = new CourseApplication(applicantId, courseCode);
            application.Status = ApplicationStatus.InProgress;
            var addedApplication = await _unitOfWork.Applications.AddAsync(application);
            if(addedApplication != null)
            {
                var result = await _unitOfWork.Save();
                var dto = new ApplicationDTO
                {
                    ApplicationId = addedApplication.ApplicantId,
                    CourseCode = course.CourseCode,
                    FirstName = applicant.FirstName,
                    Surname = applicant.Surname,
                    MiddleName = applicant.MiddleName,
                    Email = applicant.Email,
                    Address = _mapper.Map<AddressDTO>(applicant.Address),
                    Status = addedApplication.Status.ToString()

                };
                return result > 0 ? dto : throw new MySQLException();
            }
            throw new BadRequestException("Unable to create application.");


        }
    }
}
