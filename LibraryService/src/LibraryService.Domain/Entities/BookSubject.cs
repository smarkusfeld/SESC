using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryService.Domain.Common;
using LibraryService.Domain.DataModels;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.Domain.Entities
{
   
    public class BookSubject 
    {

        public string ISBN { get; private set; }
        public int SubjectId { get; private set; }
        public string SubjectName { get; private set; }
        public Book Book { get; private set; } = null!;
        public Subject Subject { get; private set; } = null!;
        public BookSubject(string isbn, int subjectId, string name)
        {
            ISBN = isbn;
            SubjectId = subjectId;
            SubjectName = name;
        }
    }
}
