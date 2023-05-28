using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.DTOs
{
    public class BookCopyDTO
    {
        public int ID { get; set; }
        public bool IsAvailable { get; set; }

        public string ISBN { get; set; }
    }
}
