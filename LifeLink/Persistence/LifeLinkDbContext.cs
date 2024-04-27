using LifeLink.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeLink.Persistence;

public class LifeLinkDbContext(DbContextOptions<LifeLinkDbContext> options) : DbContext(options)
{
    public DbSet<Parameter> Parameter { get; set; } = null!;
    public DbSet<EvacPerson> EvacPerson { get; set; } = null!;
    public DbSet<User> User { get; set; } = null!;
    public DbSet<FieldOperator> FieldOperator { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LifeLinkDbContext).Assembly);
    }
}