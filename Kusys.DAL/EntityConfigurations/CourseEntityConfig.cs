using Kusys.Domains.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kusys.DAL.EntityConfigurations;

public class CourseEntityConfig : IEntityTypeConfiguration<Course>

{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasIndex(s => s.Id).IsUnique();
        builder.Property(s => s.Id).ValueGeneratedOnAdd();

        builder.Property(s => s.Code).IsRequired();
        builder.HasIndex(s => s.Code).IsUnique();

        builder.Property(s => s.Name).IsRequired();

        builder.HasMany(s => s.Students);
    }
}