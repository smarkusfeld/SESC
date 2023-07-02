using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Models.DTOs
{
    public class StudentDTO
    {
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }

        public int TranscriptId { get; set; }

        public string FullName => string.Concat(FirstName, MiddleName, Surname);

        
    }
}
