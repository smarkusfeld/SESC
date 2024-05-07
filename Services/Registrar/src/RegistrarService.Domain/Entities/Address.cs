using RegistrarService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RegistrarService.Domain.Entities
{
    /// <summary>
    ///  Address Entity 
    ///  </summary>
    [Owned]
    public class Address 
    {


        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string Postcode { get; set; }

        public string Country { get; set; }

    }
}
