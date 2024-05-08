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

        //public string TermAddressLine1 { get; private set; }

        //public string TermAddressLine2 { get; private set; }

        //public string TermAddressLine3 { get; private set; }

        //public string TermAddressCity { get; private set; }

        //public string TermAddressRegion { get; private set; }

        //public string TermAddressPostcode { get; private set; }

        //public string TermAddressCountry { get; private set; }

        //public string PermanentAddressLine1 { get; private set; }

        //public string PermanentAddressLine2 { get; private set; }

        //public string PermanentAddressLine3 { get; private set; }

        //public string PermanentAddressCity { get; private set; }

        //public string PermanentAddressRegion { get; private set; }

        //public string PermanentAddressPostcode { get; private set; }

        //public string PermanentAddressCountry { get; private set; }


    }
}
