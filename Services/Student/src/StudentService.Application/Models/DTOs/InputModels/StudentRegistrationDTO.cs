using StudentService.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Models.DTOs.InputModels
{
    public class StudentRegistrationDTO
    {
        public int? Id { get; private set; }
        public string? StudentId { get; set; }
        public string CourseCode { get; set; }
        public int CourseOfferingId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; } = string.Empty;
        public int? OfferNumber { get; private set; }


    }
}
