using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations;

public class BootcampConfiguration : IEntityTypeConfiguration<Bootcamp>
{
    public void Configure(EntityTypeBuilder<Bootcamp> builder)
    {
        builder.ToTable("Bootcamps").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("Id");
        builder.Property(x => x.InstructorId).HasColumnName("InstructorId");
        builder.Property(x => x.BootcampStateId).HasColumnName("BootcampStateId");
        builder.Property(x => x.Name).HasColumnName("Name");
        builder.Property(x => x.StarDate).HasColumnName("StarDate");
        builder.Property(x => x.EndDate).HasColumnName("EndDate");
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(x => x.Instructor);
        builder.HasOne(x => x.BootcampState);
        builder.HasMany(x => x.Applications);
    }
}
