using Microsoft.EntityFrameworkCore;
using StudentService.Domain.Common;
using StudentService.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace StudentService.Domain.ValueObjects
{
    /// <summary>
    /// Value Object for Contact Information
    /// </summary>
    [ Owned ]
    public class Contact : ValueObject
    {

        public Student Student { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string StudentEmail { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string  AlternateEmail { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string PhoneNumber { get; set; }

        //nested owned entity 
        public Address TermAddress { get; set; }
        public Address PermanentAddress { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StudentEmail;
            yield return AlternateEmail; 
            yield return PhoneNumber;
            yield return TermAddress;
            yield return PermanentAddress;
            yield return TermAddress;
            yield return PermanentAddress;

        }
    }
}
