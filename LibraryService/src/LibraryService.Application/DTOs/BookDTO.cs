using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.DTOs
{
    public class BookDTO
    {
     
        public string Title { get; set; }
        
        public List<string> Authors { get; set; }
        public int Year { get; set; }
        public int Copies { get; set; }

        
        public int ISBN { get; set; }
    }
}
