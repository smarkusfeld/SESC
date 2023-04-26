using FinanceMicroservice.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace FinanceMicroservice.Infastructure.Context
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
           
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }

        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            // Add the shadow properties for foreign keys to the model
            modelBuilder.Entity<Payment>()
                .Property<int>("InventoryID");
            modelBuilder.Entity<Payment>()
                .Property<int>("AccountID");
            modelBuilder.Entity<Invoice>()
                .Property<int>("AccountID");

            //add foreign keys
            modelBuilder.Entity<Account>()
                .HasMany(y => y.Invoices)
                .WithOne(x => x.Account);

            modelBuilder.Entity<Account>()
                .HasMany(y => y.Payments)
                .WithOne(x => x.Account);

            modelBuilder.Entity<Invoice>()
              .HasMany(y => y.Payments)
              .WithOne(x => x.Invoice);



            //make table names singular
            modelBuilder.Entity<Account>()
               .ToTable("Accounts");
            modelBuilder.Entity<Invoice>()
              .ToTable("Invoice");
            modelBuilder.Entity<Payment>()
                .ToTable("Payment");
        }
    }


}