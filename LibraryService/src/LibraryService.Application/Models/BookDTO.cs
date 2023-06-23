using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Models
{
    public class BookDTO
    {
     
        public string Title { get; private set; }
        
        public int Year { get; private set; }
        public int TotalCount { get; private set; }
        public int AvailableCopies { get; private set; }

        //book detail fields
        public string Edition { get; private set; }
        public string Weight { get; private set; }
        public int PageCount { get; private set; }
        public string Pagination { get; private set; }
        public string PublicationLocation { get; private set; }
        public string PublicationDate { get; private set; }


    }
}
