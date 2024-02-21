using RegistrarService.Domain.Common;
using RegistrarService.Domain.Common.Enums;
using RegistrarService.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Domain.Entities
{
    /// <summary>
    /// Applicant Entity for storing data related to prospective students 
    /// </summary>
    public class Applicant : BaseAuditableEntity
    {

        public Applicant()
        {

        }
        public override object Key => ApplicantId;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicantId { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }
        
        public string MiddleName { get; set; }

        public string Email { get; set; }

        public Address Address { get; set; }


        //navigation properties
        public ICollection<CourseApplication> Applicantions { get; set; } = new List<CourseApplication>();

    }
}
