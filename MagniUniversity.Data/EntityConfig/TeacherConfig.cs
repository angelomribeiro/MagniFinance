using MagniUniversity.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace MagniUniversity.Data.EntityConfig
{
    public class TeacherConfig : EntityTypeConfiguration<Teacher>
    {
        public TeacherConfig()
        {
            ToTable("teacher");

            HasKey(p => p.TeacherId)
                .Property(p => p.TeacherId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed);

            Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            Property(p => p.Salary)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            Property(p => p.BirthDay)
                .IsRequired()
                .HasColumnType("date");
        }
    }
}
