using MagniUniversity.Data.Entity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MagniUniversity.Data.Context
{
    public class MagniUniversityContext : DbContext
    {
        public MagniUniversityContext() : base("MagniUniversityContext") 
        {            
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MagniUniversityContext, Migrations.Configuration>());
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
