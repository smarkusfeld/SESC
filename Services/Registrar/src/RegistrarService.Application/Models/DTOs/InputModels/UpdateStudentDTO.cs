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

        public AddressDTO TermAddress { get; private set; }

        public AddressDTO PermanentAddress { get; private set; }
    }
}
