using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Models
{
    public class UpdatePinDTO
    {
        public string AccountId { get; set; }
        public string OldPin { get; set; }
        public string NewPin { get; set; }
    }
}
