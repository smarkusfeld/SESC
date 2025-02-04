using RegistrarService.Application.Models.DTOs.ReponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Models.DTOs.InputModels
{
    public class NewApplicantDTO
    {

        public string FirstName { get; set; }
        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public string Email { get; set; }

        public AddressDTO Address { get; set; }

        public ApplicationDTO Applications { get; set; }

    }
}
