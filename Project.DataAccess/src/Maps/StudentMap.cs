using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.DataAccess.Entities.Concretes;

namespace Project.DataAccess.Maps
{
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("student");
            builder.HasIndex(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().HasColumnName("id");
            builder.Property(p => p.Name).IsRequired().HasColumnName("name");
            builder.Property(p => p.LastName).IsRequired().HasColumnName("last_name");
            builder.Property(p => p.BirthDate).IsRequired().HasColumnName("birth_date");

            builder
                .HasMany(p => p.Relations)
                .WithMany(p => p.Relations)
                .UsingEntity<Dictionary<string, object>>(
                    "student_career",
                    j => j.HasOne<Career>().WithMany().HasForeignKey("career_id"),
                    j => j.HasOne<Student>().WithMany().HasForeignKey("student_id")
                );
        }
    }
}
