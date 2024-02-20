using Microsoft.EntityFrameworkCore;
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
        public DbSet<Applicantion> Applicantions { get; set; }
        public DbSet<Assesment> Assesments { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseLevel> CourseLevels { get; set; }
        public DbSet<CourseModule> CourseModules { get; set; }
        public DbSet<Enrolment> Enrolments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<CourseModule> Modules { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Subjects { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<Transcript> Transcript { get; set; }

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

            //configure owned types           

            modelBuilder.Entity<Student>()
                .OwnsOne(x => x.Transcript, t =>
                {
                    t.WithOwner().HasForeignKey("StudentId");
                    t.HasKey(x => x.Id);
                });

            //no reverse navigation
            modelBuilder.Entity<Transcript>()
                .HasOne(y => y.Course)
                .WithMany()
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Result>()
                   .HasOne(y => y.Transcript)
                   .WithMany(x => x.Results)
                   .HasForeignKey(x => x.TranscriptId);

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

            //no reverse navigation for contained award
            modelBuilder.Entity<ContainedAward>()
               .HasOne(y => y.Award)
               .WithMany()
               .HasForeignKey(y => y.AwardId);

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
                .WithOne(x => x.Account)
                .HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<Student>()
                .HasMany(y => y.Registrations)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<Transcript>()
               .HasMany(y => y.Results)
               .WithOne(x => x.Transcript)
               .HasForeignKey(x => x.TranscriptId);         

            modelBuilder.Entity<Award>()
                .HasMany(y => y.Courses)
                .WithOne(x => x.Award)
                .HasForeignKey(x => x.AwardId);

            modelBuilder.Entity<Session>()
                .HasMany(x => x.SessionModules)
                .WithOne(y=>y.Session)
                .HasForeignKey(x => x.ModuleId);

            modelBuilder.Entity<CourseLevel>()
                .HasMany(x => x.Sessions)
                .WithOne(y => y.CourseLevel)
                .HasForeignKey(x => x.CourseLevelId);

            modelBuilder.Entity<CourseLevel>()
                .HasMany(x => x.CourseModules)
                .WithOne(y => y.CourseLevel)
                .HasForeignKey(x => x.CourseLevelId);

            modelBuilder.Entity<CourseModule>()
               .HasMany(x => x.SessionModules)
               .WithOne(y => y.CourseModule)
               .HasForeignKey(x=> x.ModuleId);

            modelBuilder.Entity<AcademicYear>()
               .HasMany(x => x.AcademicTerms)
               .WithOne(y => y.AcademicYear)
               .HasForeignKey(x => x.AcademicYearId);

            modelBuilder.Entity<AcademicYear>()
               .HasMany(x => x.Sessions)
               .WithOne(y => y.AcademicYear)
               .HasForeignKey(x => x.AcademicYearId);

            modelBuilder.Entity<AcademicTerm>()
               .HasMany(x => x.Sessions)
               .WithOne(y => y.AcademicTerm)
               .HasForeignKey(x => x.AcademicTermId);

            modelBuilder.SeedDatabase();

        }
    }
}
