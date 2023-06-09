using LibraryService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.Entities
{
    public class AccountType : BaseEntity
    {
        public override object Key => Id;
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
