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
        public override object Key => ApplicantNumber;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicantNumber { get; set; }

        //navigation properties
        public ICollection<Applicantion> Applicantions { get; set; } = new List<Applicantion>();

    }
}
