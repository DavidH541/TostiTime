using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TostiTime.Core.Entities;

namespace TostiTime.Data;

public class TostiTimeDb : DbContext
{
    public DbSet<Office> Offices => Set<Office>();
    public DbSet<Iron> Irons => Set<Iron>();
    public DbSet<Slot> Slots => Set<Slot>();
    public DbSet<Person> Persons => Set<Person>();
    public DbSet<Reservation> Reservations => Set<Reservation>();

    public TostiTimeDb(DbContextOptions<TostiTimeDb> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}