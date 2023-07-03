using Microsoft.EntityFrameworkCore;
using StudentService.Domain.Entities;
using System.Reflection;

namespace StudentService.Infastructure.Context
{
    /// <summary>
    /// Entity Framework DbContext
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseOffering> CourseOfferings { get; set; }
        public DbSet<CourseResult> CourseResults { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Enrolment> Enrolments { get; set; }
        public DbSet<CourseRegistration> CourseRegistrations { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Qualification> QualificationLevels { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Transcript> Transcripts { get; set; }

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
            //apply all types in the assembly that implment IEntityTypeConfiguration 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //configure alternate key for course entity
            modelBuilder.Entity<Course>()
                 .HasAlternateKey(x=> new { x.CourseCode, x.IsActive });

            //configure owned types
            modelBuilder.Entity<Student>().OwnsOne(
                x=> x.ContactDetail, cd =>
                {
                    cd.ToTable("Contact");
                    cd.WithOwner(y => y.Student);
                    cd.Navigation(y => y.Student).UsePropertyAccessMode(PropertyAccessMode.Property);
                    cd.OwnsOne(y => y.PermanentAddress);
                    cd.OwnsOne(y => y.TermAddress);
                });

            modelBuilder.Entity<Student>().OwnsOne(x => x.Transcript, x => { x.ToTable("Transcript"); });

            //add foreign keys

            modelBuilder.Entity<Course>()
                .HasMany(y => y.Enrolments)
                .WithOne(x => x.Course)
                .HasForeignKey(x => x.CourseId);

            modelBuilder.Entity<Student>()
                .HasMany(y => y.Enrolments)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<Student>()
                .HasMany(y => y.Registrations)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<Student>()
                .HasOne(y => y.Transcript)
                .WithOne(x => x.Student)
                .HasForeignKey<Transcript>(x => x.StudentId);

            //no reverse navigation
            modelBuilder.Entity<Transcript>()
                .HasOne(y => y.Course)
                .WithMany()
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Transcript>()
                .HasMany(y => y.Results)
                .WithOne(x => x.Transcript)
                .HasForeignKey(x => x.TranscriptId);

            modelBuilder.Entity<CourseResult>()
                .HasOne(x => x.CourseOffering)
                .WithMany()
                .HasForeignKey(x => x.CourseOfferingId);

            modelBuilder.Entity<CourseResult>()
                .HasOne(x => x.Qualification).WithMany()
                .HasForeignKey(x => x.QualificationId)
                .IsRequired(false);

            modelBuilder.Entity<Course>()
                .HasMany(y=> y.CourseOfferings)
                .WithOne(x => x.Course)
                .HasForeignKey(x => x.CourseId);

            modelBuilder.Entity<School>()
                .HasMany(y=>y.Courses)
                .WithOne(x=>x.School)
                .HasForeignKey(x => x.SchoolId);

            modelBuilder.Entity<Degree>()
                .HasMany(y => y.Courses)
                .WithOne(x => x.Degree)
                .HasForeignKey(x => x.DegreeId);        

            modelBuilder.Entity<CourseOffering>()
                .HasMany(y => y.Requirements)
                .WithOne(x => x.CourseOffering)
                .HasForeignKey(x => x.CourseOfferingId);

            modelBuilder.Entity<Requirement>()
                .HasOne(y => y.Qualification)
                .WithMany()
                .HasForeignKey(x => x.QualificationId);

        }
    }
}
