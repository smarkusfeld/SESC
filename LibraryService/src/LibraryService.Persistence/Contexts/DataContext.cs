using LibraryService.Domain.Common.Enums;
using LibraryService.Domain.Common.Interfaces;
using LibraryService.Domain.DataModels;
using LibraryService.Domain.Entities;
using LibraryService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.Persistence.Context
{
    /// <summary>
    /// Entity Framework DbContext
    /// </summary>
    public class DataContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;
        public DataContext(DbContextOptions<DataContext> options, IDomainEventDispatcher dispatcher) : base(options)
        {
            _dispatcher = dispatcher;
        }

        //public DbSet<AccountModel> Clubs => Set<AccountModel>();
        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<BookModel> BookCopies { get; set; }
        public DbSet<Rack> Racks { get; set; }
        public DbSet<LoanModel> Loans { get; set; }
        public DbSet<ReservationModel> Reservations { get; set; }
        public DbSet<AuthorModel> Authors { get; set; }
        public DbSet<BookAuthor>BookAuthors { get; set; }
        public DbSet<PublisherModel> Publishers { get; set; }
        public DbSet<BookPublisher> BookPublishers { get; set; }
        public DbSet<SubjectModel> Subjects { get; set; }
        public DbSet<BookSubject> BookSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configure alternate keys
            modelBuilder.Entity<AccountModel>().HasAlternateKey(x => x.AccountNum);

            //configure composite keys
            modelBuilder.Entity<BookSubjectModel>().HasKey(x => new { x.ISBN, x.SubjectId });
            modelBuilder.Entity<BookAuthorModel>().HasKey(x => new { x.ISBN, x.AuthorId });
            modelBuilder.Entity<BookPublisherModel>().HasKey(x => new { x.ISBN, x.PublisherId });

            //enum to string conversions
            modelBuilder.Entity<LoanModel>()
                .Property(l => l.Status)
                .HasConversion(s => s.ToString(), s => (LoanStatus)Enum.Parse(typeof(LoanStatus), s));

            modelBuilder.Entity<ReservationModel>()
                .Property(l => l.Status)
                .HasConversion(s => s.ToString(), s => (ReservationStatus)Enum.Parse(typeof(ReservationStatus), s));


            //configure owned types
            modelBuilder.Entity<AccountModel>().OwnsOne(a => a.AccountType);
            modelBuilder.Entity<BookModel>().OwnsOne(b => b.Detail);
            modelBuilder.Entity<BookModel>().OwnsOne(b => b.Identifier);
            modelBuilder.Entity<BookModel>().OwnsOne(b => b.Classification);
            modelBuilder.Entity<BookCopyModel>().OwnsOne(b => b.Rack, b => { b.ToTable("rack"); });

            //add foreign keys
            modelBuilder.Entity<AccountModel>().HasMany(y => y.Loans).WithOne(x => x.Account).HasForeignKey(x => x.AccountId);
            modelBuilder.Entity<AccountModel>().HasMany(y => y.Reservations).WithOne(x => x.Account).HasForeignKey(x => x.AccountId);
            modelBuilder.Entity<BookCopyModel>().HasMany(y => y.Loans).WithOne(x => x.BookCopy).HasForeignKey(x => x.BookCopyId);
            modelBuilder.Entity<BookCopyModel>().HasMany(y => y.Reservations).WithOne(x => x.BookCopy).HasForeignKey(x => x.BookCopyId);

            //add foreign keys for many to many relationships
            modelBuilder.Entity<BookModel>().HasMany(y => y.BookSubjects).WithOne(x => x.Book).HasForeignKey(x => x.ISBN);
            modelBuilder.Entity<BookModel>().HasMany(y => y.BookAuthors).WithOne(x => x.Book).HasForeignKey(x => x.ISBN);            
            modelBuilder.Entity<BookModel>().HasMany(y => y.BookPublishers).WithOne(x => x.Book).HasForeignKey(x => x.ISBN);

            modelBuilder.Entity<SubjectModel>().HasMany(y => y.BookSubjects).WithOne(x => x.Subject).HasForeignKey(x => x.SubjectId);
            modelBuilder.Entity<AuthorModel>().HasMany(y => y.BookAuthors).WithOne(x => x.Author).HasForeignKey(x => x.AuthorId);
            modelBuilder.Entity<PublisherModel>().HasMany(y => y.BookPublishers).WithOne(x => x.Publisher).HasForeignKey(x => x.PublisherId);

            
                     

            
        }
    }
}
