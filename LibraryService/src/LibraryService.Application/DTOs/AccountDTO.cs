using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.DTOs
{
    public class AccountDTO
    {
        public int ID { get; set; }
        public string StudentID { get; set; }

        public int Pin { get; set; } = 000000;

    }
}
