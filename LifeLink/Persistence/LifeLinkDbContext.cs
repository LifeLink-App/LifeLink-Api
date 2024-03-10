using LifeLink.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeLink.Persistence;

public class LifeLinkDbContext : DbContext
{
    public LifeLinkDbContext(DbContextOptions<LifeLinkDbContext> options)
    {

    }

    public DbSet<EvacPerson> EvacPersons { get; set; } = null!;
}