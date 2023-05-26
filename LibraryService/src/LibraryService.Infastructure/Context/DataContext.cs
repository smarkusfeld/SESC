using LibraryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509;
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
        public DbSet<BookCopy> BookCopies { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor>BookAuthors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookPublisher> BookPublishers { get; set; }
        public DbSet<Identifier> Identifiers { get; set; }
        public DbSet<BookIdentifier> BookIdentifiers { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<BookClassification> BookClassifications { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<BookSubject> BookSubjects { get; set; }
       
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
             .HasMany(y => y.BookClassifications)
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

            modelBuilder.Entity<Classification>()
             .HasMany(y => y.BookClassifications)
             .WithOne(x => x.Classification);

            modelBuilder.Entity<Identifier>()
             .HasMany(y => y.BookIdentifiers)
             .WithOne(x => x.Identifier);

            modelBuilder.Entity<Publisher>()
             .HasMany(y => y.BookPublishers)
              .WithOne(x => x.Publisher);


        }
    }
}
