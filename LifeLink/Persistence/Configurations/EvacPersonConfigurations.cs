using LifeLink.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeLink.Persistence.Configurations;

public class EvacPersonConfigurations : IEntityTypeConfiguration<EvacPerson>
{
    public void Configure(EntityTypeBuilder<EvacPerson> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedNever();

        builder.Property(e => e.Name)
            .HasMaxLength(EvacPerson.MaxNameLength);

        builder.Property(e => e.Description)
            .HasMaxLength(EvacPerson.MaxDescriptionLength);

        builder.Property(e => e.Medications)
            .HasConversion(
                v => string.Join(",", v.Select(guid => guid.ToString())),
                v => v.Split(",", StringSplitOptions.RemoveEmptyEntries)
                        .Select(guidStr => Guid.Parse(guidStr.Trim())) 
                        .ToList());
    }
}