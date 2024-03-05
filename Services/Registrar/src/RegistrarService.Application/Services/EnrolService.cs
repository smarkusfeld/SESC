using AutoMapper;
using RegistrarService.Application.Common.Exceptions;
using RegistrarService.Application.Interfaces.Repositories;
using RegistrarService.Application.Interfaces.Services;
using RegistrarService.Application.Models.DTOs.InputModels;
using RegistrarService.Application.Models.DTOs.ReponseModels;
using RegistrarService.Domain.Common.Enums.StudentService.Domain.Common.Enums;
using RegistrarService.Domain.Entities;

namespace RegistrarService.Application.Services
{
    public class EnrolService : IEnrolService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EnrolService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EnrolmentDTO> Enrol(int courseCode)
        {
            throw new NotImplementedException();
        }

        public async Task<EnrolmentDTO> Enrol(int studentId, int courseCode)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EnrolmentDTO>> GetAllEnrolments(string studentId)
        {
            throw new NotImplementedException();
        }
    }
}
