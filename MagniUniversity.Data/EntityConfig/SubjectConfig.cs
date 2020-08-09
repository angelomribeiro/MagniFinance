using MagniUniversity.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace MagniUniversity.Data.EntityConfig
{
    public class SubjectConfig : EntityTypeConfiguration<Subject>
    {
        public SubjectConfig()
        {
            ToTable("subject");

            HasKey(p => p.SubjectId)
                .Property(p => p.SubjectId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed);

            Property(p => p.Title)
                .IsRequired()
                .HasColumnType("varchar(100)");

            HasRequired(p => p.Teacher)
                .WithMany(p => p.Subjects)
                .HasForeignKey(c => c.TeacherId);

            HasRequired(p => p.Course)
                .WithMany(p => p.Subjects)
                .HasForeignKey(c => c.CourseId);
        }
    }
}
