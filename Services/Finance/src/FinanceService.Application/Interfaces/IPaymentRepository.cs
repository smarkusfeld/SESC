﻿using FinanceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Application.Interfaces
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
    }
}
