using AutoMapper;
using StudentService.Application.Common.Exceptions;
using StudentService.Application.Interfaces.Repositories;
using StudentService.Application.Interfaces.Services;
using StudentService.Application.Models.DTOs.InputModels;
using StudentService.Application.Models.DTOs.ReponseModels;
using StudentService.Domain.Entities;
using System.ComponentModel;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;

namespace StudentService.Application.Services
{
    public class AccountService : IAccountService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AccountDTO> AddStudentAccount(string studentId)
        {
            var check = await _unitOfWork.Accounts.GetAsync(studentId);
            if (check != null) { throw new BadRequestException($"Account already exists for {studentId}"); }

            var account = await _unitOfWork.Accounts.AddAsync(new Account(studentId));
            if(await _unitOfWork.Save() < 0)
            {
                 throw new BadRequestException();
            } 
            return _mapper.Map<AccountDTO>(account);
        }

        public Task<AccountDTO> AddProgressionResult(ProgressionDTO progresion)
        {
            throw new NotImplementedException();
        }

        public async Task<AccountDTO> GetStudentAccount(string studentId)
        {
            //get student account
            var result = await _unitOfWork.Accounts.GetAsync(studentId) 
                ?? throw new KeyNotFoundException($"No Account Associated with Student {studentId}");

            return _mapper.Map<AccountDTO>(result);
        }

       
        


       
    }
}
