using FinanceService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Infastructure.Context
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


            modelBuilder.Entity<Invoice>()
                .Property(x => x.Balance)
                .HasColumnType("decimal(8,2)");

            modelBuilder.Entity<Invoice>()
                .Property(x => x.Total)
                .HasColumnType("decimal(8,2)");

            modelBuilder.Entity<Payment>()
               .Property(x => x.Amount)
               .HasColumnType("decimal(8,2)");

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

        }
    }


}