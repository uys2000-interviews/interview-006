using Microsoft.EntityFrameworkCore;
using ServerApplication.Models;

namespace ServerApplication.Data;

public class FixturesContext : DbContext
{
    public FixturesContext (DbContextOptions<FixturesContext> options)
        : base(options) {}

    public DbSet<Fixture> Fixtures => Set<Fixture>();
    public DbSet<Personnel> Personnels => Set<Personnel>();
    public DbSet<Debit> Debits => Set<Debit>();
}