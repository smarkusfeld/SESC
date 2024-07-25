using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1.X509;
using RegistrarService.Domain.Entities;
using System.Diagnostics;
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
        public DbSet<CourseApplication> Applications { get; set; }
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

            modelBuilder.Entity<Programme>()
               .HasOne(x => x.Subject)
               .WithMany(y => y.Programmes)
               .HasForeignKey(x => x.SubjectId);

            modelBuilder.Entity<Programme>()
               .HasOne(x => x.School)
               .WithMany(y => y.Programmes)
               .HasForeignKey(x => x.SchoolId);

            modelBuilder.Entity<Programme>()
              .HasOne(x => x.Award)
              .WithMany(y => y.Programmes)
              .HasForeignKey(x => x.AwardId);

            modelBuilder.Entity<Course>()
                .HasOne(x => x.Programme)
                .WithMany(y => y.Courses)
                .HasForeignKey(x => x.ProgrammeCode);

            modelBuilder.Entity<CourseLevel>()
                .HasOne(y => y.Course)
                .WithMany(x => x.CourseLevels)
                .HasForeignKey(x => x.CourseCode);

            modelBuilder.Entity<CourseLevel>()
                .HasOne(y => y.AcademicYear)
                .WithMany(x => x.CourseLevels)
                .HasForeignKey(x => x.AcademicYearId);

            modelBuilder.Entity<CourseApplication>()
                .HasOne(y => y.Course)
                .WithMany(x => x.CourseApplications)
                .HasForeignKey(x => x.CourseCode);

            modelBuilder.Entity<Enrolment>()
                .HasOne(y => y.CourseLevel)
                .WithMany(x => x.Enrolments)
                .HasForeignKey(x => x.CourseLevelId);

            modelBuilder.Entity<Enrolment>()
                .HasOne(y => y.Student)
                .WithMany(x => x.Enrolments)
                .HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<ProgressionResult>()
                .HasOne(y => y.Student)
                .WithMany(x => x.Results)
                .HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<ProgressionResult>()
                .HasOne(y => y.CourseLevel)
                .WithMany(x => x.Results)
                .HasForeignKey(x => x.CourseLevelId);

            modelBuilder.SeedDatabase();

        }
    }
}
