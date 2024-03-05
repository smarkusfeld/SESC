using AutoMapper;
using RegistrarService.Application.Common.Exceptions;
using RegistrarService.Application.Interfaces.Repositories;
using RegistrarService.Application.Interfaces.Services;
using RegistrarService.Application.Models.DTOs.InputModels;
using RegistrarService.Application.Models.DTOs.ReponseModels;
using RegistrarService.Domain.Entities;
using System.ComponentModel;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;

namespace RegistrarService.Application.Services
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

        public async Task<AccountDTO> AddStudentAccount(int studentId)
        {
            var check = await _unitOfWork.Accounts.GetAsync(studentId);
            if (check != null) { throw new BadRequestException($"Account already exists for {studentId}"); }

            var account = await _unitOfWork.Accounts.AddAsync(new Student(studentId));
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

        public async Task<AccountDTO> GetStudentAccount(int studentId)
        {
            //get student account
            var result = await _unitOfWork.Accounts.GetAsync(studentId) 
                ?? throw new KeyNotFoundException($"No Account Associated with Student {studentId}");

            return _mapper.Map<AccountDTO>(result);
        }

       
        


       
    }
}
