using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Domain.Common.Enums
{
    public enum EnrolStatus
    {
        Active,
        Withdrawn,
        Withdrawn_Fail,
        Transferred,
        Completed,
        Completed_NoCredit,
        Completed_Fail,
        Fail_Repeat
        
    }
}
