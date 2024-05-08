using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Models.DTOs.InputModels
{
    public class NewStudentDTO
    {
        public int ApplicantId { get; private set; }
        public string FirstName { get; private set; }
        public string Surname { get; private set; }
        public string MiddleName { get; private set; }

        public string Email { get; private set; }

        public AddressDTO TermAddress { get; private set; }

        public AddressDTO PermanentAddress { get; private set; }
    }
}
