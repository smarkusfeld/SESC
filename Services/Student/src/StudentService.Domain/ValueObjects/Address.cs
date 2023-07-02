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
    public class Address : ValueObject
    {
        public string LineOne { get; set; }
        public string? LineTwo { get; set; }
        public string? LineThree { get; set; }
        public string Town_City { get; set; }
        public string? County_Region { get; set; }
        public string PostCode { get; set; }

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
