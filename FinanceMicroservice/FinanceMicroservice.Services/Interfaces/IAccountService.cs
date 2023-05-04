

using FinanceMicroservice.Application.DTOs;
using FinanceMicroservice.Domain.Entities;
using FinanceMicroservice.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinanceMicroservice.Application.Interfaces
{
    
    public interface IAccountService : IGenericService<AccountDTO>
    {

    }
}
