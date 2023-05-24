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
        public DbSet<BookCopy> BookCopys { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor>BookAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Account>()
                .HasMany(y => y.Loans)
                .WithOne(x => x.Account);

            modelBuilder.Entity<BookCopy>()
                .HasMany(y => y.Loans)
                .WithOne(x => x.BookCopy);

            modelBuilder.Entity<Book>()
              .HasMany(y => y.BookCopys)
              .WithOne(x => x.Book);

            modelBuilder.Entity<Book>()
               .HasMany(y => y.BookAuthors)
              .WithOne(x => x.Book);

            modelBuilder.Entity<Book>()
              .HasMany(y => y.BookSubjects)
             .WithOne(x => x.Book);

            modelBuilder.Entity<Book>()
             .HasMany(y => y.BookClassifiers)
            .WithOne(x => x.Book);

            modelBuilder.Entity<Book>()
             .HasMany(y => y.BookIdentifiers)
            .WithOne(x => x.Book);

            modelBuilder.Entity<Book>()
             .HasMany(y => y.BookPublishers)
            .WithOne(x => x.Book);

            modelBuilder.Entity<Author>()
               .HasMany(y => y.BookAuthors)
              .WithOne(x => x.Author);

            modelBuilder.Entity<Subject>()
                .HasMany(y => y.BookSubjects)
                .WithOne(x => x.Subject);

            modelBuilder.Entity<Classifier>()
             .HasMany(y => y.BookClassifiers)
            .WithOne(x => x.Classifier);

            modelBuilder.Entity<Identifier>()
             .HasMany(y => y.BookIdentifiers)
            .WithOne(x => x.Identifier);

            modelBuilder.Entity<Publisher>()
             .HasMany(y => y.BookPublishers)
            .WithOne(x => x.Publisher);
        }
    }
}
