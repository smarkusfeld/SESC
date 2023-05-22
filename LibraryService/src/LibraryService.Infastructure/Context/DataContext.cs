using LibraryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Infastructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookItem> BookItems { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<TitleAuthor> TitleAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Account>()
                .HasMany(y => y.Loans)
                .WithOne(x => x.Account);

            modelBuilder.Entity<BookItem>()
                .HasMany(y => y.Loans)
                .WithOne(x => x.BookItem);

            modelBuilder.Entity<Book>()
              .HasMany(y => y.BookItems)
              .WithOne(x => x.Book);

            modelBuilder.Entity<Book>()
               .HasMany(y => y.TitleAuthors)
              .WithOne(x => x.Book);

            modelBuilder.Entity<Author>()
               .HasMany(y => y.TitleAuthors)
              .WithOne(x => x.Author);
        }
    }
}
