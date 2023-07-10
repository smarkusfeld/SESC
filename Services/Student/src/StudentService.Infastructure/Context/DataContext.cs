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
        public DbSet<CourseLevel> CourseOfferings { get; set; }
        public DbSet<StudentResult> CourseResults { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<ContainedAward> ContainedAwards { get; set; }
        public DbSet<Enrolment> Enrolments { get; set; }
        public DbSet<CourseRegistration> CourseRegistrations { get; set; }
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
                    
                    cd.WithOwner(y => y.Student);
                    cd.Navigation(y => y.Student).UsePropertyAccessMode(PropertyAccessMode.Property);
                    cd.OwnsOne(y => y.PermanentAddress);
                    cd.OwnsOne(y => y.TermAddress);
                });

           
            //add foreign keys
            modelBuilder.Entity<Course>()
                .HasMany(y => y.CourseLevels)
                .WithOne(x => x.Course)
                .HasForeignKey(x => x.CourseId);

            modelBuilder.Entity<Course>()
                .HasMany(y => y.Registrations)
                .WithOne(x => x.Course)
                .HasForeignKey(x => x.CourseId);

            modelBuilder.Entity<Course>()
               .HasMany(y => y.ContainedAwards)
               .WithOne(x => x.Course)
               .HasForeignKey(x => x.CourseId);

            modelBuilder.Entity<Course>()
               .HasOne(x => x.School)
               .WithMany(y => y.Courses)               
               .HasForeignKey(x => x.SchoolId);

            modelBuilder.Entity<Course>()
               .HasOne(x => x.Subject)
               .WithMany(y => y.Courses)
               .HasForeignKey(x => x.SubjectId);

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

            modelBuilder.Entity<StudentResult>()
                   .HasOne(y => y.Transcript)
                   .WithMany(x => x.Results)
                   .HasForeignKey(x => x.TranscriptId);

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


            modelBuilder.Entity<StudentResult>()
                .HasOne(x => x.CourseLevel)
                .WithMany()
                .HasForeignKey(x => x.CourseLevelId);           

            modelBuilder.Entity<Award>()
                .HasMany(y => y.Courses)
                .WithOne(x => x.Award)
                .HasForeignKey(x => x.AwardId);

            modelBuilder.SeedDatabase();

        }
    }
}
