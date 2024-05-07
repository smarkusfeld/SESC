using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Models.DTOs.ReponseModels
{
    public class ApplicantDTO
    {
        public int ApplicantId { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public string Email { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string Postcode { get; set; }

        public string Country { get; set; }

        public IEnumerable<ApplicationDTO> Applications { get; set; }
    }

    public class ApplicationDTO
    {
        public int ApplicantId { get; set; }

        public string CourseCode { get; set; }

        public string Status { get; set; }
    }
}
