using RegistrarService.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Models.DTOs.InputModels
{
    public class NewApplicationDTO
    {
        public int ApplicantId { get; set; }

        public string CourseCode { get; set; }  

        public string Statement { get; set; }

        public string Status { get; set; }
    }
}
