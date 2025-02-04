using RegistrarService.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Models.DTOs.InputModels
{
    public class AwardDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abbr { get; set; }
        public int QualificationLevel { get; set; }
        public QualificationType QualificationType { get; set; }

        public DegreeCategory DegreeCategory { get; set; }
    }
}
