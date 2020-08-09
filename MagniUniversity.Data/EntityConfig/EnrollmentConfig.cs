using MagniUniversity.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace MagniUniversity.Data.EntityConfig
{
    public class EnrollmentConfig : EntityTypeConfiguration<Enrollment>
    {
        public EnrollmentConfig()
        {
            ToTable("enrollment");

            HasKey(p => p.EnrollmentId)
                .Property(p => p.EnrollmentId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed);

            Property(p => p.Grade)
                .HasColumnType("varchar(5)");

            HasRequired(p => p.Student)
                .WithMany(p => p.Enrollments)
                .HasForeignKey(c => c.StudentId);

            HasRequired(p => p.Subject)
                .WithMany(p => p.Enrollments)
                .HasForeignKey(c => c.SubjectId);
        }
    }
}
