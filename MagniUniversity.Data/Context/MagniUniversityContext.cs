using MagniUniversity.Data.Entity;
using MagniUniversity.Data.EntityConfig;
using System.Data.Entity;

namespace MagniUniversity.Data.Context
{
    public class MagniUniversityContext : DbContext
    {
        public MagniUniversityContext() : base("MagniUniversityContext") 
        {
            Database.SetInitializer(new MagniUniversityInitializer());
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseConfig());
            modelBuilder.Configurations.Add(new EnrollmentConfig());
            modelBuilder.Configurations.Add(new StudentConfig());
            modelBuilder.Configurations.Add(new SubjectConfig());
            modelBuilder.Configurations.Add(new TeacherConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
