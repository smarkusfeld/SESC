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
        public DbSet<CourseApplication> Applicantions { get; set; }
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
                    t.ToTable("Transcript");
                    t.Navigation(s => s.Student).UsePropertyAccessMode(PropertyAccessMode.Property);
                    t.HasKey(x => x.Id);
                });

            //no reverse navigation
            modelBuilder.Entity<Transcript>()
                .HasOne(y => y.Course)
                .WithMany()
                .HasForeignKey(x => x.CourseCode)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Result>()
                   .HasOne(y => y.Transcript)
                   .WithMany(x => x.Results)
                   .HasForeignKey(x => x.TranscriptId);

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
                .HasMany(y => y.CourseModules)
                .WithOne(x => x.CourseLevel)
                .HasForeignKey(x => x.CourseLevelId);

            modelBuilder.Entity<CourseLevel>()
                .HasMany(y => y.Enrolments)
                .WithOne(x => x.CourseLevel)
                .HasForeignKey(x => x.CourseLevelId);

            modelBuilder.Entity<AcademicTerm>()
                .HasMany(y => y.CourseModules)
                .WithOne(x => x.AcademicTerm)
                .HasForeignKey(x => x.AcademicTermId);

            modelBuilder.Entity<CourseModule>()
                .HasMany(y => y.Sessions)
                .WithOne(x => x.CourseModule)
                .HasForeignKey(x => x.CRN);

            modelBuilder.Entity<CourseModule>()
                .HasMany(y => y.Components)
                .WithOne(x => x.CourseModule)
                .HasForeignKey(x => x.CRN);

            modelBuilder.Entity<Component>()
                .HasMany(y => y.Assesments)
                .WithOne(x => x.Component)
                .HasForeignKey(x => x.ComponentId);

            modelBuilder.Entity<AcademicModule>()
                .HasMany(y => y.CourseModules)
                .WithOne(x => x.Module)
                .HasForeignKey(x => x.CRN);

            modelBuilder.Entity<Session>()
                .HasMany(y => y.Timetables)
                .WithOne(x => x.Session)
                .HasForeignKey(x => x.SessionCode);

            modelBuilder.Entity<Location>()
                .HasMany(y => y.Timetables)
                .WithOne(x => x.Location)
                .HasForeignKey(x => x.LocationId);


            modelBuilder.Entity<Result>()
               .HasMany(y => y.Assesments)
               .WithOne(x => x.Result)
               .HasForeignKey(x => x.AssesmentId);


            modelBuilder.Entity<Student>()
                .HasMany(y => y.Enrolments)
                .WithOne(x => x.Account)
                .HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<Student>()
                .HasMany(y => y.Registrations)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId);


            modelBuilder.SeedDatabase();

        }
    }
}
