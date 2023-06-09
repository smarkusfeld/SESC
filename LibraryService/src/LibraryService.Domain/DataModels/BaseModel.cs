using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.DataModels
{
    public abstract class BaseModel
    {
        public object Key { get; }
    }
}
