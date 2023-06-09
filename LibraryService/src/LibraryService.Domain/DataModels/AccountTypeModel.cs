using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryService.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.Domain.DataModels
{
    [Owned]
    public class AccountTypeModel 
    {

        public string? Name { get; set; }
        public string? Description { get; set; }

    }
}
