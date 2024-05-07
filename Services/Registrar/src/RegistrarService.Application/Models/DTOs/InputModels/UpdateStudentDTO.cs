using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Models.DTOs.InputModels
{
    public class UpdateStudentDTO
    {
        public int StudentId { get; private set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }

        public string StudentEmail { get; set; }

        public string AlternateEmail { get; set; }

        public string Status { get; set; }

        public string TermAddressLine1 { get; set; }

        public string TermAddressLine2 { get; set; }

        public string TermAddressLine3 { get; set; }

        public string TermAddressCity { get; set; }

        public string TermAddressRegion { get; set; }

        public string TermAddressPostcode { get; set; }

        public string TermAddressCountry { get; set; }

        public string PermanentAddressLine1 { get; set; }

        public string PermanentAddressLine2 { get; set; }

        public string PermanentAddressLine3 { get; set; }

        public string PermanentAddressCity { get; set; }

        public string PermanentAddressRegion { get; set; }

        public string PermanentAddressPostcode { get; set; }

        public string PermanentAddressCountry { get; set; }
    }
}
