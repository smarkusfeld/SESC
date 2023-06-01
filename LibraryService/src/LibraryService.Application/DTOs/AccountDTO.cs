using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.DTOs
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string StudentId { get; set; }

        public int Pin { get; set; } = 000000;

    }
}
