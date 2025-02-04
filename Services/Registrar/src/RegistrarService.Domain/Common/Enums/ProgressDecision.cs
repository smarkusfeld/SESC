using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Domain.Common.Enums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace StudentService.Domain.Common.Enums
    {
        public enum ProgressDecision
        {
            pass_proceed,
            awarded,
            deffered,
            reassesment,
            failed_complete,
            failed_repeat,
            failed_withdraw,
            contained_award
        }
    }
}