using Moq;
using RegistrarService.Application.Interfaces;
using RegistrarService.Api.Controllers;
using RegistrarService.Application.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using RegistrarService.Application.Services;
using RegistrarService.Domain.Entities;
using Microsoft.Identity.Client;
using System.Security.Principal;
using AutoMapper.Execution;
using RegistrarService.Application.Interfaces.Repositories;

namespace RegistrarService.UnitTests
{
    public class StudentServiceTests
    {
        private readonly IMapper mapper;
        private readonly Mock<IUnitOfWork> unitOfWork;
        public StudentServiceTests()
        {

            unitOfWork = new Mock<IUnitOfWork>();
            mapper = new MappingTests().mapper;
        }
    }
}
