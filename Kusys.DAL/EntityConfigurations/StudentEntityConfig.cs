using Kusys.Domains.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kusys.DAL.EntityConfigurations;

public class StudentEntityConfig : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedOnAdd();
        builder.Property(s => s.FirstName).IsRequired();
        builder.Property(s => s.LastName).IsRequired();

        // we  could create relations from here too, but I preferred to create relation in "CourseEntityConfig.cs" file
        // builder.HasOne<Course>(s => s.Course);
    }
}