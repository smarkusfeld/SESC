using RegistrarService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Domain.Entities
{
    /// <summary>
    ///  Building Entity
    ///  </summary>
    public class Building : BaseAuditableEntity
    {
        private Building() { }


        public Building(string code, string name)
        {
            BuildingCode = code;
            BuildingName = name;
        }
        public override object Key => BuildingCode;

        [Key]
        public string BuildingCode { get; set; }

        public string BuildingName { get; set; }


    }
}
