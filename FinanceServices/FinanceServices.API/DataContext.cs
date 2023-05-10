using Microsoft.EntityFrameworkCore;
using System;

namespace FinanceServices.API
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
