using LifeLink.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeLink.Persistence;

public class LifeLinkDbContext : DbContext
{
    public LifeLinkDbContext(DbContextOptions<LifeLinkDbContext> options): base(options)
    {

    }

    public DbSet<EvacPerson> EvacPersons { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LifeLinkDbContext).Assembly);
    }
}