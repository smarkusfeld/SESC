using Microsoft.EntityFrameworkCore;
using StudentService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Domain.ValueObjects
{
    /// <summary>
    /// Value object for address properties
    /// </summary>
    [Owned]
    public class Address : ValueObject
    {
        [Column(TypeName = "varchar(100)")]
        public string LineOne { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? LineTwo { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? LineThree { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Town_City { get; set; }
        
        [Column(TypeName = "varchar(50)")] 
        public string? County_Region { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string PostCode { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Country { get; set; }

        

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // return each element one at a time

            
            yield return LineOne + LineTwo + LineThree;
            yield return Town_City;
            yield return PostCode;
            yield return Country;

        }
    }
}
