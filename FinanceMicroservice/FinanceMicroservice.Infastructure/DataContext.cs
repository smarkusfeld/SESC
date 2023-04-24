using FinanceMicroservice.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceMicroservice.Infastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
            public DbSet<Account> Accounts { get; set; }
            public DbSet<Invoice> Invoices { get; set; }
    }
    }
}
