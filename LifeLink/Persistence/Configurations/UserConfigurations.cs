using LifeLink.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeLink.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedNever();

        builder.Property(e => e.Username)
            .HasMaxLength(Constants.MaxNameLength);
    
        builder.Property(e => e.Name)
            .HasMaxLength(Constants.MaxNameLength);

        builder.Property(e => e.Roles)
            .HasConversion(
                v => string.Join(",", v.Select(guid => guid.ToString())),
                v => v.Split(",", StringSplitOptions.RemoveEmptyEntries)
                        .Select(guidStr => Guid.Parse(guidStr.Trim())) 
                        .ToList());
    }
}