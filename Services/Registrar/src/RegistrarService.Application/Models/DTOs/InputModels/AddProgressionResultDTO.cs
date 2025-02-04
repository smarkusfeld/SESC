using RegistrarService.Domain.Common.Enums.StudentService.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Models.DTOs.InputModels
{
    public class AddProgressionResultDTO
    {
        public string ProgressDecision { get; set; }
        public DateTime ProgressDate { get; set; }
        public string? ProgressNotes { get; set; }
        public string StudentId { get; set; }
        public int CourseLevelId { get; set; }
    }
}
