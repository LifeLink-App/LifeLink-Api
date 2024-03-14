using LifeLink.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeLink.Persistence;

public class LifeLinkDbContext(DbContextOptions<LifeLinkDbContext> options) : DbContext(options)
{
    public DbSet<EvacPerson> EvacPerson { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LifeLinkDbContext).Assembly);
    }
}