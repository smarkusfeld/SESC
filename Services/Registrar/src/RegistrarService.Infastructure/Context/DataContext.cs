using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509;
using RegistrarService.Domain.Entities;
using System.Reflection;
using System.Reflection.Emit;

namespace RegistrarService.Infastructure.Context
{
    /// <summary>
    /// Entity Framework DbContext
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<AcademicTerm> AcademicTerms { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<CourseApplication> Applicantions { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseLevel> CourseLevels { get; set; }
        public DbSet<Enrolment> Enrolments { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<ProgressionResult> Results { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Subjects { get; set; }

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

            //owned objects
            modelBuilder.Entity<Student>()
                .OwnsOne(x => x.TermAddress);
            modelBuilder.Entity<Student>()
                .OwnsOne(x => x.PermanentAddress);

            //add foreign keys
            modelBuilder.Entity<Applicant>()
               .HasMany(y => y.Applicantions)
               .WithOne(x => x.Applicant)
               .HasForeignKey(x => x.ApplicantId);

            modelBuilder.Entity<Award>()
               .HasMany(y => y.Programmes)
               .WithOne(x => x.Award)
               .HasForeignKey(x => x.ProgrammeCode); 
            
            modelBuilder.Entity<Subject>()
               .HasMany(y => y.Programmes)
               .WithOne(x => x.Subject)
               .HasForeignKey(x => x.ProgrammeCode);
            
            modelBuilder.Entity<School>()
               .HasMany(y => y.Programmes)
               .WithOne(x => x.School)
               .HasForeignKey(x => x.ProgrammeCode);

            modelBuilder.Entity<Programme>()
               .HasMany(y => y.Courses)
               .WithOne(x => x.Programme)
               .HasForeignKey(x => x.ProgrammeCode);

            modelBuilder.Entity<Course>()
                .HasMany(y => y.CourseLevels)
                .WithOne(x => x.Course)
                .HasForeignKey(x => x.CourseCode);

            modelBuilder.Entity<Course>()
                .HasMany(y => y.CourseApplications)
                .WithOne(x => x.Course)
                .HasForeignKey(x => x.CourseCode);

            modelBuilder.Entity<AcademicYear>()
                .HasMany(y => y.CourseLevels)
                .WithOne(x => x.AcademicYear)
                .HasForeignKey(x => x.AcademicYearId);

            modelBuilder.Entity<CourseLevel>()
                .HasMany(y => y.Enrolments)
                .WithOne(x => x.CourseLevel)
                .HasForeignKey(x => x.CourseLevelId);


            modelBuilder.Entity<Student>()
                .HasMany(y => y.Enrolments)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<Student>()
                .HasMany(y => y.Results)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<CourseLevel>()
                .HasMany(y => y.Results)
                .WithOne(x => x.CourseLevel)
                .HasForeignKey(x => x.CourseLevelId);

            modelBuilder.SeedDatabase();

        }
    }
}
