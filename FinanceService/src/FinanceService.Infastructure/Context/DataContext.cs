using FinanceService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Org.BouncyCastle.Ocsp;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Xml;

namespace FinanceService.Infastructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Account>()
                .HasMany(y => y.Invoices)
                .WithOne(x => x.Account)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Account>()
                .HasMany(y => y.Payments)
                .WithOne(x => x.Account)
               .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Invoice>()
              .HasMany(y => y.Payments)
              .WithOne(x => x.Invoice)
              .OnDelete(DeleteBehavior.Cascade);
            

            //populate date fields on creation
            modelBuilder.Entity<Payment>()
                .Property(e => e.CreatedDate)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Payment>()
                .Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            modelBuilder.Entity<Invoice>()
                .Property(e => e.CreatedDate)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Invoice>()
                .Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            modelBuilder.Entity<Account>()
                .Property(e => e.CreatedDate)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Account>()
                .Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);

            //currency column format
            //modelBuilder.Entity<Invoice>()
            //    .Property(x => x.Balance)
            //    .HasColumnType("decimal(8,2)");
            //modelBuilder.Entity<Invoice>()
            //    .Property(x => x.Total)
            //    .HasColumnType("decimal(8,2)");
            //modelBuilder.Entity<Payment>()
            //   .Property(x => x.Amount)
            //   .HasColumnType("decimal(8,2)");

            

        }
    }
}
