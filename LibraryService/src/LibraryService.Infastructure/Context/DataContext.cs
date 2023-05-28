using LibraryService.Domain.Entities;
using LibraryService.Infastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection.Emit;

namespace LibraryService.Infastructure.Context
{
    public class DataContext : IdentityDbContext<User, IdentityRole, string>
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
            //configure identity schema
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasMany(x => x.Claims).WithOne().HasForeignKey(y => y.UserId).IsRequired();
            modelBuilder.Entity<User>().HasMany(x => x.UserRoles).WithOne().HasForeignKey(y => y.UserId).IsRequired();
            modelBuilder.Entity<User>().HasMany(x => x.Logins).WithOne().HasForeignKey(y => y.UserId).IsRequired();
            modelBuilder.Entity<User>().HasMany(x => x.Tokens).WithOne().HasForeignKey(y => y.UserId).IsRequired();

            modelBuilder.Entity<Account>().HasOne(x => x.User).WithOne(y => y.Account).HasForeignKey<Account>(x => x.UserID).IsRequired();


            modelBuilder.Entity<Account>().HasMany(y => y.Loans).WithOne(x => x.Account).HasForeignKey(x => x.AccountID);

        
            modelBuilder.Entity<BookCopy>().HasMany(y => y.Loans).WithOne(x => x.BookCopy).HasForeignKey(x=>x.BookCopyID);

           
            modelBuilder.Entity<Book>().HasMany(y => y.BookCopys).WithOne(x => x.Book).HasForeignKey(x =>x.BookID);
            modelBuilder.Entity<Book>().HasMany(y => y.BookAuthors).WithOne(x => x.Book).HasForeignKey(x => x.BookID);
            modelBuilder.Entity<Book>().HasMany(y => y.BookSubjects).WithOne(x => x.Book).HasForeignKey(x => x.BookID);
            modelBuilder.Entity<Book>().HasMany(y => y.BookClassifications).WithOne(x => x.Book).HasForeignKey(x => x.BookID);
            modelBuilder.Entity<Book>().HasMany(y => y.BookIdentifiers).WithOne(x => x.Book).HasForeignKey(x => x.BookID); 
            modelBuilder.Entity<Book>().HasMany(y => y.BookPublishers).WithOne(x => x.Book).HasForeignKey(x => x.BookID);

            modelBuilder.Entity<Author>().HasMany(y => y.BookAuthors).WithOne(x => x.Author).HasForeignKey(x => x.AuthorID);


            

            modelBuilder.Entity<Subject>().HasMany(y => y.BookSubjects).WithOne(x => x.Subject).HasForeignKey(x => x.SubjectID);

            modelBuilder.Entity<Classification>().HasMany(y => y.BookClassifications).WithOne(x => x.Classification).HasForeignKey(x => x.ClassificationID);

            modelBuilder.Entity<Identifier>().HasMany(y => y.BookIdentifiers).WithOne(x => x.Identifier).HasForeignKey(x => x.IndentifierID);

            modelBuilder.Entity<Publisher>().HasMany(y => y.BookPublishers).WithOne(x => x.Publisher).HasForeignKey(x => x.PublisherID);
            
            
            modelBuilder.ApplyConfiguration(new ClassificationConfiguration());

            modelBuilder.ApplyConfiguration(new IndentifierConfiguration());

            
        }
    }
}
