using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.DataAccess.Entities.Concretes;

namespace Project.DataAccess.Maps
{
    public class StudentCareerMap : IEntityTypeConfiguration<StudentCareer>
    {
        public void Configure(EntityTypeBuilder<StudentCareer> builder)
        {
            builder.ToTable("StudentCareer");
            builder.HasKey(p => new { p.StudentId, p.CareerId });
            builder
                .HasOne(p => p.Student)
                .WithMany(p => p.StudentCareers)
                .HasForeignKey(p => p.StudentId);
            builder
                .HasOne(p => p.Career)
                .WithMany(p => p.StudentCareers)
                .HasForeignKey(p => p.CareerId);
        }
    }
}
