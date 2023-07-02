using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Models
{
    public class BookCopyDTO
    {
        public int Id { get; set; }
        public bool IsAvailable { get; set; }

        public string ISBN { get; set; }
    }
}
