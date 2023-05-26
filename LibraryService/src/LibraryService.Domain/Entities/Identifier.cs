﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.Domain.Entities
{
    [Table("identifier")]
    public class Identifier : IEntity
    {
            
        public string Name { get; set; }
        public ICollection<BookIdentifier> BookIdentifiers { get; set; }
    }

   
}
