using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceMicroservice.Application.Interfaces
{
    public interface IConverter<in T1, out T2>
    {
        T2 Convert(T1 source_object);
    }

}
