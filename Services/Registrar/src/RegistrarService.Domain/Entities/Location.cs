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
    ///  Location Entity
    ///  </summary>
    public class Location : BaseAuditableEntity
    {
        private Location() { }


        internal Location(int roomNumber, string building)
        {
            RoomNumber = roomNumber;
            Building = building;
        }
        public override object Key => LocationId;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }

        public int RoomNumber { get; set; }

        public string Building { get; set; }

    }
}
