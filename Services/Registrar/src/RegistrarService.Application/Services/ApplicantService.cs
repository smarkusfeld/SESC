using AutoMapper;
using RegistrarService.Application.Common.Exceptions;
using RegistrarService.Application.Interfaces.Repositories;
using RegistrarService.Application.Interfaces.Services;
using RegistrarService.Application.Models.DTOs.InputModels;
using RegistrarService.Application.Models.DTOs.ReponseModels;
using RegistrarService.Domain.Common.Enums;
using RegistrarService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ApplicantService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ApplicantDTO>> GetAllApplicants()
        {

            var result = await _unitOfWork.Applicants.GetAllAsync();
            if (result != null)
            {
                return _mapper.Map<IEnumerable<ApplicantDTO>>(result);
            }
            return Enumerable.Empty<ApplicantDTO>();


        }
        public async Task<ApplicantDTO> GetApplicant(int applicantId)
        {

            var result = await _unitOfWork.Applicants.GetAsync(applicantId)
                ?? throw new KeyNotFoundException($"No Account Associated with Applicant {applicantId}");
            return _mapper.Map<ApplicantDTO>(result);


        }
        public async Task<ApplicantDTO> UpdateApplicant(UpdateApplicantDTO applicant)
        {
            //get student account
            var account = await _unitOfWork.Applicants.GetAsync(applicant.ApplicantId)
                ?? throw new KeyNotFoundException($"No Account Associated with Applicant {applicant.ApplicantId}");
            //validate account updates
            List<string> errors = new();
            
            //add more validation rules
            if (errors.Any()) { throw new BadRequestException("Invalid Request", errors); }

            //update account 
            account.FirstName = applicant.FirstName;
            account.MiddleName = applicant.MiddleName;
            account.Surname = applicant.Surname;
            account.Email = applicant.Email.Normalize().ToLowerInvariant();
            account.Address = _mapper.Map<Address>(applicant.Address);

            var update = _unitOfWork.Applicants.Update(account);
            if (update != null)
            {
                var result = await _unitOfWork.Save();
                return result > 0 ? _mapper.Map<ApplicantDTO>(update) : throw new MySQLException("MySQL Error. Changes not saved");
            }
            throw new BadRequestException("Unable to update applicant account");
        }
        public async Task<ApplicantDTO> AddApplicant(NewApplicantDTO applicantDTO)
        {
            string normalizedEmail = applicantDTO.Email.Normalize().ToLowerInvariant();
            var check = await _unitOfWork.Applicants.GetByAsync(x => x.Email.Equals(normalizedEmail));
            if (check != null) { throw new BadRequestException($"Applicant already exists for {applicantDTO.Email}"); }
            var applicant = _mapper.Map<Applicant>(applicantDTO);
            var newApplicant = await _unitOfWork.Applicants.AddAsync(applicant);
            if (await _unitOfWork.Save() < 0)
            {
                throw new BadRequestException();
            }
            return _mapper.Map<ApplicantDTO>(newApplicant);
        }

     
        
    }
}
