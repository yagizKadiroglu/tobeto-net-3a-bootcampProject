using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations;

public class ApplicationStateConfiguration : IEntityTypeConfiguration<ApplicationState>
{
    public void Configure(EntityTypeBuilder<ApplicationState> builder)
    {
        builder.ToTable("ApplicationStates").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("Id");
        builder.Property(x => x.Name).HasColumnName("Name");
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(x => x.Applications);
    }
}
