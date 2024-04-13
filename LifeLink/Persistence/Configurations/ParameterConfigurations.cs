using LifeLink.Helpers;
using LifeLink.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeLink.Persistence.Configurations;

public class ParameterConfigurations : IEntityTypeConfiguration<Parameter>
{
    public void Configure(EntityTypeBuilder<Parameter> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedNever();

        builder.Property(e => e.GroupKey)
            .HasMaxLength(Constants.MaxNameLength);
    
        builder.Property(e => e.ParameterKey)
            .HasMaxLength(Constants.MaxNameLength);

        builder.Property(e => e.Value)
            .HasMaxLength(Constants.MaxNameLength);
        
        builder.Property(e => e.ExtraValue)
            .HasMaxLength(Constants.MaxNameLength);
    }
}