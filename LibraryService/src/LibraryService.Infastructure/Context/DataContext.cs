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
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("user_login");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("user_token");
            modelBuilder.Entity<IdentityRole>().ToTable("role");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("role_claim");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("user_role");


            modelBuilder.Entity<User>().HasMany(x => x.Claims).WithOne().HasForeignKey(y => y.UserId).IsRequired();
            modelBuilder.Entity<User>().HasMany(x => x.UserRoles).WithOne().HasForeignKey(y => y.UserId).IsRequired();
            modelBuilder.Entity<User>().HasMany(x => x.Logins).WithOne().HasForeignKey(y => y.UserId).IsRequired();
            modelBuilder.Entity<User>().HasMany(x => x.Tokens).WithOne().HasForeignKey(y => y.UserId).IsRequired();

            modelBuilder.Entity<User>().HasOne(x => x.Account).WithOne(y => y.User).HasForeignKey<User>(x => x.AccountId);

            modelBuilder.Entity<Account>().HasMany(y => y.Loans).WithOne(x => x.Account).HasForeignKey(x => x.AccountId);        
            modelBuilder.Entity<BookCopy>().HasMany(y => y.Loans).WithOne(x => x.BookCopy).HasForeignKey(x=>x.BookCopyId);           
            modelBuilder.Entity<Book>().HasMany(y => y.BookCopys).WithOne(x => x.Book).HasForeignKey(x =>x.BookId);
            modelBuilder.Entity<Book>().HasMany(y => y.BookAuthors).WithOne(x => x.Book).HasForeignKey(x => x.BookId);
            modelBuilder.Entity<Book>().HasMany(y => y.BookSubjects).WithOne(x => x.Book).HasForeignKey(x => x.BookId);
            modelBuilder.Entity<Book>().HasMany(y => y.BookClassifications).WithOne(x => x.Book).HasForeignKey(x => x.BookId);
            modelBuilder.Entity<Book>().HasMany(y => y.BookIdentifiers).WithOne(x => x.Book).HasForeignKey(x => x.BookId); 
            modelBuilder.Entity<Book>().HasMany(y => y.BookPublishers).WithOne(x => x.Book).HasForeignKey(x => x.BookId);

            modelBuilder.Entity<Author>().HasMany(y => y.BookAuthors).WithOne(x => x.Author).HasForeignKey(x => x.AuthorId);          

            modelBuilder.Entity<Subject>().HasMany(y => y.BookSubjects).WithOne(x => x.Subject).HasForeignKey(x => x.SubjectId);

            modelBuilder.Entity<Classification>().HasMany(y => y.BookClassifications).WithOne(x => x.Classification).HasForeignKey(x => x.ClassificationID);

            modelBuilder.Entity<Identifier>().HasMany(y => y.BookIdentifiers).WithOne(x => x.Identifier).HasForeignKey(x => x.IndentifierId);

            modelBuilder.Entity<Publisher>().HasMany(y => y.BookPublishers).WithOne(x => x.Publisher).HasForeignKey(x => x.PublisherId);
            
            
            modelBuilder.ApplyConfiguration(new ClassificationConfiguration());

            modelBuilder.ApplyConfiguration(new IndentifierConfiguration());

            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            
        }
    }
}
