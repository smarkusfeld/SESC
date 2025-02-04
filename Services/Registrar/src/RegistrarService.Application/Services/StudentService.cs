using AutoMapper;
using Microsoft.VisualBasic;
using RegistrarService.Application.Common.Exceptions;
using RegistrarService.Application.Interfaces.Repositories;
using RegistrarService.Application.Interfaces.Services;
using RegistrarService.Application.Models.DTOs.InputModels;
using RegistrarService.Application.Models.DTOs.ReponseModels;
using RegistrarService.Domain.Common.Enums;
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
            if (await _unitOfWork.Save() < 0)
            {
                throw new BadRequestException();
            }
            return _mapper.Map<StudentAccountDTO>(newStudent);
        }

        public async Task<StudentProgressionDTO> GetProgressionResults(int studentId)
        {
            //get student account
            var check = await _unitOfWork.Students.GetAsync(studentId);
            if (check != null)
            {
                var student = new StudentProgressionDTO()
                {
                    StudentId = check.StudentId,
                    FirstName = check.FirstName,
                    Surname = check.Surname,
                    MiddleName = check.MiddleName,
                    Status = check.Status.ToString()

                };
                var result = await _unitOfWork.Results.GetStudentResults(studentId);
                if (result != null)
                {
                    var results = _mapper.Map<IEnumerable<ProgressionDTO>>(result);
                    student.Results = results;
                }
                return student;
            }
            throw new KeyNotFoundException($"No Account Associated with Student {studentId}");

        }
        public async Task<IEnumerable<StudentAccountDTO>> GetStudentAccounts()
        {

            var result = await _unitOfWork.Students.GetAllAsync();
            if (result != null)
            {
                return _mapper.Map<IEnumerable<StudentAccountDTO>>(result);
            }
            return Enumerable.Empty<StudentAccountDTO>();


        }
        public async Task<StudentAccountDTO> GetStudentAccount(int studentId)
        {
            var result = await _unitOfWork.Students.GetAsync(studentId)
                ?? throw new KeyNotFoundException($"No Account Associated with Student {studentId}");
            return _mapper.Map<StudentAccountDTO>(result);
        }

        public async Task<StudentAccountDTO> UpdateStudentAccount(int studentId, UpdateStudentDTO student)
        {
            //get student account
            var account = await _unitOfWork.Students.GetAsync(studentId)
                ?? throw new KeyNotFoundException($"No Account Associated with Student {studentId}");
            //validate account updates
            List<string> errors = new();
            if (!Enum.TryParse(student.Status, true, out StudentStatus status))
            {
                errors.Add($"Invalid Account Status: {status}");
            }
            //add more validation rules
            if (errors.Any()) { throw new BadRequestException("Invalid Request", errors); }

            //update account 
            account.Status = status;
            account.FirstName = student.FirstName;
            account.MiddleName = student.MiddleName;
            account.Surname = student.Surname;
            account.AlternateEmail = student.AlternateEmail;
            account.StudentEmail = student.StudentEmail;
            account.PermanentAddress = _mapper.Map<Address>(student.PermanentAddress);
            account.TermAddress = _mapper.Map<Address>(student.PermanentAddress);
            var update = _unitOfWork.Students.Update(account);
            if (update != null)
            {
                var result = await _unitOfWork.Save();
                return result > 0 ? _mapper.Map<StudentAccountDTO>(update) : throw new MySQLException("MySQL Error. Changes not saved");
            }
            throw new BadRequestException("Unable to update student account");
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