using LifeLink.Helpers;
using LifeLink.Models;
using LifeLink.Models.BaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeLink.Persistence.Configurations;

public class FieldOperatorConfiguration : IEntityTypeConfiguration<FieldOperator>
{
    public void Configure(EntityTypeBuilder<FieldOperator> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedNever();
    
        builder.Property(e => e.Location)
            .HasConversion(
                coordinate => $"{coordinate.Latitude}-{coordinate.Longitude}",
                coordinateStr => new Coordinate(coordinateStr)                    
            );
            
        builder.Property(e => e.LocationNote)
            .HasMaxLength(Constants.MaxDescriptionLength);

        builder.Property(e => e.AssignedEvacPersons)
            .HasConversion(
                v => string.Join(",", v.Select(guid => guid.ToString())),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(guidStr => Guid.Parse(guidStr.Trim()))
                    .ToList())
            .Metadata.SetValueComparer(
                new ValueComparer<List<Guid>>(
                    (c1, c2) =>
                        c1 == null && c2 == null || (c1 != null && c2 != null && c1.SequenceEqual(c2)),
                    c => c == null ? 0 : c.Aggregate(0, (hash, guid) => HashCode.Combine(hash, guid.GetHashCode())),
                    c => c == null ? new List<Guid>() : new List<Guid>(c)));
    }
}
