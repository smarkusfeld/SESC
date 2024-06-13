using RegistrarService.Application.Models.DTOs.InputModels;
using RegistrarService.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Models.DTOs.ReponseModels
{   
    
    /// <summary>
     /// Data Transfer Object for student account details
     /// <br> View only to protect data models</br>
     /// </summary>
    public class StudentAccountDTO
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }

        public string StudentEmail { get; set; }

        public string AlternateEmail { get;  set; }

        public string Status { get; set; }

        public AddressDTO TermAddress { get;  set; }

        public AddressDTO PermanentAddress { get; set; }


    }
}
