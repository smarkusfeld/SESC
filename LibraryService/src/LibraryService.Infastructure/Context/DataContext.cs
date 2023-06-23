using LibraryService.Domain.Common.Enums;
using LibraryService.Domain.Entities;
using LibraryService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.Infastructure.Context
{
    /// <summary>
    /// Entity Framework DbContext
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
           
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
        public DbSet<Rack> Racks { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor>BookAuthors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookPublisher> BookPublishers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<BookSubject> BookSubjects { get; set; }

        /// <summary>
        /// Override Method to save changes async
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configure alternate keys
            modelBuilder.Entity<Account>().HasAlternateKey(x => x.AccountNum);

            //configure composite keys
            modelBuilder.Entity<BookSubject>().HasKey(x => new { x.ISBN, x.SubjectId });
            modelBuilder.Entity<BookAuthor>().HasKey(x => new { x.ISBN, x.AuthorId });
            modelBuilder.Entity<BookPublisher>().HasKey(x => new { x.ISBN, x.PublisherId });

            //enum to string conversions
            modelBuilder.Entity<Loan>()
                .Property(l => l.Status)
                .HasConversion(s => s.ToString(), s => (LoanStatus)Enum.Parse(typeof(LoanStatus), s));

            modelBuilder.Entity<Reservation>()
                .Property(l => l.Status)
                .HasConversion(s => s.ToString(), s => (ReservationStatus)Enum.Parse(typeof(ReservationStatus), s));

            modelBuilder.Entity<Account>()
                .Property(a => a.AccountType)
                .HasConversion(s => s.ToString(), s => (AccountType)Enum.Parse(typeof(AccountType), s));

            //configure owned types

            modelBuilder.Entity<Book>().OwnsOne(b => b.Detail);
            modelBuilder.Entity<Book>().OwnsOne(b => b.Identifier);
            modelBuilder.Entity<Book>().OwnsOne(b => b.Classification);          
            modelBuilder.Entity<BookCopy>().OwnsOne(b => b.Rack, b => { b.ToTable("rack"); });

            //add foreign keys
            modelBuilder.Entity<Account>().HasMany(y => y.Loans).WithOne(x => x.Account).HasForeignKey(x => x.AccountId);
            modelBuilder.Entity<Account>().HasMany(y => y.Reservations).WithOne(x => x.Account).HasForeignKey(x => x.AccountId);
            modelBuilder.Entity<BookCopy>().HasMany(y => y.Loans).WithOne(x => x.BookCopy).HasForeignKey(x => x.BookCopyId);
            modelBuilder.Entity<BookCopy>().HasMany(y => y.Reservations).WithOne(x => x.BookCopy).HasForeignKey(x => x.BookCopyId);

            //add foreign keys for many to many relationships
            modelBuilder.Entity<Book>().HasMany(y => y.BookSubjects).WithOne(x => x.Book).HasForeignKey(x => x.ISBN).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Book>().HasMany(y => y.BookAuthors).WithOne(x => x.Book).HasForeignKey(x => x.ISBN).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Book>().HasMany(y => y.BookPublishers).WithOne(x => x.Book).HasForeignKey(x => x.ISBN).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Subject>().HasMany(y => y.BookSubjects).WithOne(x => x.Subject).HasForeignKey(x => x.SubjectId);
            modelBuilder.Entity<Author>().HasMany(y => y.BookAuthors).WithOne(x => x.Author).HasForeignKey(x => x.AuthorId);
            modelBuilder.Entity<Publisher>().HasMany(y => y.BookPublishers).WithOne(x => x.Publisher).HasForeignKey(x => x.PublisherId);

            
                     

            
        }
    }
}
