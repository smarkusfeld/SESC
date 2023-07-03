using AutoMapper;
using StudentService.Application.Common.Exceptions;
using StudentService.Application.Interfaces.Repositories;
using StudentService.Application.Interfaces.Services;
using StudentService.Application.Models.DTOs;
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

        public async Task<StudentDetailedDTO> GetStudentAccountDetail(string studentId)
        {
            //get student account
            var result = await _unitOfWork.Students.GetAsync(studentId)
                ?? throw new KeyNotFoundException($"No Account Associated with Student {studentId}");

            return _mapper.Map<StudentDetailedDTO>(result);
        }

        public async Task<StudentTranscriptDTO> GetStudentTranscript(string studentId)
        {
            var result = await _unitOfWork.Students.GetTranscriptAsync(studentId)
                ?? throw new KeyNotFoundException($"No Account Associated with Student {studentId}");

            return _mapper.Map<StudentTranscriptDTO>(result);
        }
        public async Task<StudentDetailedDTO> UpdateContactInformation(StudentDetailedDTO dto)
        {
            var validationErrors = await ValidateStudentAccountDetails(dto);
            if (validationErrors != null)
            {
                throw new BadRequestException(validationErrors.Message, validationErrors.Details);
            }
            var updatedAccount = _mapper.Map<Student>(dto);
            var update = await _unitOfWork.Students.UpdateAsync(updatedAccount)
                ?? throw new BadRequestException("Unable to update account."); 
            
            var result = await _unitOfWork.Save();
            return result > 0 ? _mapper.Map<StudentDetailedDTO>(result) : throw new MySQLException();
        }

        //Validate Account
        public async Task<ErrorDetail?> ValidateStudentAccountDetails(StudentDetailedDTO dto)
        {
            List<string> validationErrors = new List<string>();
            var account = await _unitOfWork.Students.GetTranscriptAsync(dto.StudentId);
            if(account == null)
            {
                validationErrors.Add($"No Account Associated with Student {dto.StudentId}");
            }

            //TODO: add other validation rules

            if (validationErrors.Any())
            {
                return new ErrorDetail("Unable to update account.", validationErrors);
            }
            else
            {
                return null;
            }

        }

        

    }
}
