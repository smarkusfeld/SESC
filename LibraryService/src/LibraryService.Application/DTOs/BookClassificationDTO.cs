﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.DTOs
{
    public class BookClassificationDTO
    {
        
        public string Value { get; set; }

        public int ClassificationID { get; set; }
        public int BookId { get; set; }

    }
}
