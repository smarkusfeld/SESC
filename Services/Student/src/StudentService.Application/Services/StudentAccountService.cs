using AutoMapper;
using StudentService.Application.Common.Exceptions;
using StudentService.Application.Interfaces.Repositories;
using StudentService.Application.Interfaces.Services;
using StudentService.Application.Models.DTOs;
using StudentService.Application.Models.DTOs.InputModels;
using StudentService.Domain.Entities;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace StudentService.Application.Services
{
    public class StudentAccountService : IStudentAccountService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StudentAccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<StudentDTO> GetStudentAccount(string studentId)
        {
            //get student account
            var result = await _unitOfWork.Students.GetAsync(studentId) 
                ?? throw new KeyNotFoundException($"No Account Associated with Student {studentId}");

            return _mapper.Map<StudentDTO>(result);
        }

        public async Task<UpdateStudentContactDTO> GetStudentAccountDetail(string studentId)
        {
            //get student account
            var result = await _unitOfWork.Students.GetAsync(studentId)
                ?? throw new KeyNotFoundException($"No Account Associated with Student {studentId}");

            return _mapper.Map<UpdateStudentContactDTO>(result);
        }

        public async Task<StudentTranscriptDTO> GetStudentTranscript(string studentId)
        {
            var result = await _unitOfWork.Students.GetTranscriptAsync(studentId)
                ?? throw new KeyNotFoundException($"No Account Associated with Student {studentId}");

            return _mapper.Map<StudentTranscriptDTO>(result);
        }
        public async Task<UpdateStudentContactDTO> UpdateContactInformation(UpdateStudentContactDTO dto)
        {
            if(await ValidateStudentAccountDetails(dto))
            {
                var updatedAccount = _mapper.Map<Student>(dto);
                var update = await _unitOfWork.Students.UpdateAsync(updatedAccount);
                if (update != null)
                {
                    var result = await _unitOfWork.Save();
                    return result > 0 ? _mapper.Map<UpdateStudentContactDTO>(result) : throw new MySQLException();

                }                
            }
            throw new BadRequestException("Unable to update account.");

        }

        //Validate Account
        public async Task<bool> ValidateStudentAccountDetails(UpdateStudentContactDTO dto)
        {
            var validation = new ErrorDetail();
           
            var account = await _unitOfWork.Students.GetAsync(dto.StudentId);
            if(account == null)
                validation.Details.Add($"No Account Associated with Student {dto.StudentId}");
            if (dto.TermAddressLineOne.Trim().Length == 0)
                validation.Details.Add("Term Address Line One isRequired");
            if (dto.TermAddressTown_City.Trim().Length == 0)
                validation.Details.Add("Term Address Town or City is Required");
            if (dto.TermAddressPostCode.Trim().Length == 0)
                validation.Details.Add("Term Address Post Code is Required");
            if (dto.TermAddressCountry.Trim().Length == 0)
                validation.Details.Add("Term Address Country is Required");
            if (dto.PermanentAddressLineOne.Trim().Length == 0)
                validation.Details.Add("Permanent Address Line One isRequired");
            if (dto.PermanentAddressTown_City.Trim().Length == 0)
                validation.Details.Add("Permanent Address Town or City is Required");
            if (dto.PermanentAddressPostCode.Trim().Length == 0)
                validation.Details.Add("Permanent Address Post Code is Required");
            if (dto.PermanentAddressCountry.Trim().Length == 0)
                validation.Details.Add("Permanent Address Country is Required");           
            //TODO: add other validation rules

            if (validation.Details.Any())
            {
                validation.Message = "Invalid Account";
                throw new BadRequestException("Bad Request", validation);
            }
            return true; 

        }

        

    }
}
