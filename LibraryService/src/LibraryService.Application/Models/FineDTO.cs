using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Models
{
    public class FineDTO
    {
        public DateTime? FineDate { get; set; } 
        public decimal Amount { get; set; }
        public string AccountId { get; set; }
        public bool FineIssued { get; set; }
    }
}
