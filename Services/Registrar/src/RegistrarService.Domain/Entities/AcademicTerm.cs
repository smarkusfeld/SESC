using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistrarService.Domain.Common;

namespace RegistrarService.Domain.Entities
{
    /// <summary>
    /// Academic Term Entity 
    /// </summary>
    public class AcademicTerm : BaseAuditableEntity
    {

        public AcademicTerm(string name, int academicYearID, DateTime startDate, DateTime endDate)
        {
            Name = name;
            AcademicYearID = academicYearID;
            StartDate = startDate;
            EndDate = endDate;          
        }

        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int AcademicYearID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //navigation properties
        public AcademicYear AcademicYear { get; set; }

        

    }
}
