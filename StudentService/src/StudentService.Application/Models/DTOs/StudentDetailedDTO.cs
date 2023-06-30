using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Models.DTOs
{
    public class StudentDetailedDTO
    {
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }

        public int TranscriptId { get; set; }

        public string FullName => string.Concat(FirstName, MiddleName, Surname);

        public string StudentEmail { get; set; }
        public string AlternateEmail { get; set; }
        public string PhoneNumber { get; set; }

        public string TermAddressLineOne { get; set; }
        public string? TermAddressLineTwo { get; set; }
        public string? TermAddressLineThree { get; set; }
        public string TermAddressTown_City { get; set; }
        public string? TermAddressCounty_Region { get; set; }
        public string TermAddressPostCode { get; set; }

        public string TermAddressCountry { get; set; }

        public string PermanentAddressLineOne { get; set; }
        public string? PermanentAddressLineTwo { get; set; }
        public string? PermanentAddressLineThree { get; set; }
        public string PermanentAddressTown_City { get; set; }
        public string? PermanentAddressCounty_Region { get; set; }
        public string PermanentAddressPostCode { get; set; }
        public string PermanentAddressCountry { get; set; }
    }
}
