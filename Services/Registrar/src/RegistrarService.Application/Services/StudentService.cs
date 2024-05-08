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
    public class StudentService : IStudentService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<StudentProgressionDTO> AddProgressionResult(AddProgressionResultDTO result)
        {
            throw new NotImplementedException();
        }

        public async Task<StudentAccountDTO> AddStudentAccount(NewStudentDTO studentDTO)
        {
            string normalizedEmail = studentDTO.Email.Normalize().ToUpperInvariant();
            var check = await _unitOfWork.Students.GetByAsync(x => x.AlternateEmail.Normalize().ToUpperInvariant().Equals(normalizedEmail));
            if (check != null) { throw new BadRequestException($"Student already exists for {studentDTO.Email}"); }

            var student = _mapper.Map<Student>(studentDTO);
            student.StudentEmail = await CreateStudentEmail(studentDTO.FirstName, studentDTO.Surname);           

            var newStudent = await _unitOfWork.Students.AddAsync(student);
            if(await _unitOfWork.Save() < 0)
            {
                 throw new BadRequestException();
            } 
            return _mapper.Map<StudentAccountDTO>(newStudent);
        }

        public async Task<StudentProgressionDTO> GetProgressionResults(int studentId)
        {
            //get student account
            var result = await _unitOfWork.Students.GetAsync(studentId)
                ?? throw new KeyNotFoundException($"No Account Associated with Student {studentId}");

            return _mapper.Map <StudentProgressionDTO>(result);
        }
        public async Task<IEnumerable<StudentAccountDTO>> GetStudentAccounts()
        {
            //get student account
            var result = await _unitOfWork.Students.GetAllAsync()
                ?? throw new KeyNotFoundException($"No students found");

            return _mapper.Map <IEnumerable<StudentAccountDTO>>(result);
        }
        public async Task<StudentAccountDTO> GetStudentAccount(int studentId)
        {
            //get student account
            var result = await _unitOfWork.Students.GetAsync(studentId) 
                ?? throw new KeyNotFoundException($"No Account Associated with Student {studentId}");

            return _mapper.Map<StudentAccountDTO>(result);
        }

        public async Task<StudentAccountDTO> UpdateStudentAccount(int studentId, UpdateStudentDTO student)
        {
            //get student account
            var check = await _unitOfWork.Students.GetAsync(studentId)
                ?? throw new KeyNotFoundException($"No Account Associated with Student {studentId}");

            var update = _mapper.Map<Student>(student);
            var result = await _unitOfWork.Students.UpdateAsync(update)
                ?? throw new MySQLException("Could not update student account");
            return _mapper.Map<StudentAccountDTO>(result);
        }

        private async Task<string> CreateStudentEmail(string firstname, string surname)
        {
            string emailHeader = surname + '.' + firstname;
            string emailDomain = "@student.school.ac.uk";
            int i = 1;
            while (true) 
            {
                string email = emailHeader + emailDomain;
                string normalizedEmail = email;
                var check = await _unitOfWork.Students.GetByAsync(x => x.AlternateEmail.Normalize().ToUpperInvariant().Equals(normalizedEmail));
                if (check == null)
                {
                    return email;   
                }
                emailHeader += i;
                i++;
            }
        }


       
    }
}
