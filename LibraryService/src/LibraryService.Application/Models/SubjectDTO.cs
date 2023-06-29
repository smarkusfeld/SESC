using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Models
{
    public class SubjectDTO : BaseAuditableModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
       
    }
}
