using MagniUniversity.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace MagniUniversity.Data.EntityConfig
{
    public class StudentConfig : EntityTypeConfiguration<Student>
    {
        public StudentConfig()
        {
            ToTable("student");

            HasKey(p => p.StudentId)
                .Property(p => p.StudentId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed);

            Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            Property(p => p.RegistrationNumber)
                .IsRequired();

            Property(p => p.BirthDay)
                .IsRequired()
                .HasColumnType("date");
        }
    }
}
