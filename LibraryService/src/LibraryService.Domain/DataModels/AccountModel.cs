
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibraryService.Domain.Common;

namespace LibraryService.Domain.DataModels
{
    [Table("account")]
    public class AccountModel : BaseModel
    {
        [Key]
        public string AccountId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountNum { get; set; }

        [Required]
        public int Pin { get; set; } = 000000;
        public AccountTypeModel AccountType { get; set; }   
        public ICollection<LoanModel>? Loans { get; set; }
        public ICollection<ReservationModel>? Reservations { get; set; }
    }
}
