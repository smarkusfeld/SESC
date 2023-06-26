using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Models
{
    public class BookDTO
    {
     
        public string Title { get; private set; }
        public string ISBN { get; private set; }
        public int BookNum { get; private set; }
        public int Year { get; private set; }
        public int TotalCount { get; private set; }
        public int AvailableCopies { get; private set; }
      
        //public string Edition { get; private set; }
        public string Weight { get; private set; }
        public int PageCount { get; private set; }
        public string Pagination { get; private set; }
        public string PublicationLocation { get; private set; }
        public string PublicationDate { get; private set; }

        public string[] Authors { get; private set; } = Array.Empty<string>();

        public string[] Publishers { get; private set; } = Array.Empty<string>();

        public string[] Subjects { get; private set; } = Array.Empty<string>();
    }
}
