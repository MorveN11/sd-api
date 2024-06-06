using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.DataAccess.Entities.Concretes;

namespace Project.DataAccess.Maps
{
    public class CareerMap : IEntityTypeConfiguration<Career>
    {
        public void Configure(EntityTypeBuilder<Career> builder)
        {
            builder.ToTable("career");
            builder.HasIndex(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().HasColumnName("id");
            builder.Property(p => p.Name).IsRequired().HasColumnName("name");
            builder.Property(p => p.Code).IsRequired().HasColumnName("code");

            builder
                .HasMany(p => p.Relations)
                .WithMany(p => p.Relations)
                .UsingEntity<Dictionary<string, object>>(
                    "student_career",
                    j => j.HasOne<Student>().WithMany().HasForeignKey("student_id"),
                    j => j.HasOne<Career>().WithMany().HasForeignKey("career_id")
                );
        }
    }
}
