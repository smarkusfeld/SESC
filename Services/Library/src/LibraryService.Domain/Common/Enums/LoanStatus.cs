using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.Common.Enums
{
    public enum LoanStatus
    {
        Active,
        Completed,
        Due,
        Overdue
    }
}
