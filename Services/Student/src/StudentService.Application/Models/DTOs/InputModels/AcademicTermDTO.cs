using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Models.DTOs.InputModels
{
    public class AcademicTermDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int AcademicYearId { get; set; }
    }
}
