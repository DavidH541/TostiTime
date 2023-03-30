using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TostiTime.Data;

namespace TostiTime.App;

public static class Program
{
    private static void Main()
    {
        var dbOptions = new DbContextOptionsBuilder<TostiTimeDb>()
                    .UseSqlServer("Data source = (localdb)\\MSSQLLocalDB; Initial Catalog = TostiTimeDb")
                    .LogTo(message => Debug.WriteLine(message))
                    .EnableSensitiveDataLogging()
                    .Options;

        using var _dbContext = new TostiTimeDb(dbOptions);
        _dbContext.Database.EnsureDeleted();
        Console.WriteLine("DB deleted");
        _dbContext.Database.EnsureCreated();
        Console.WriteLine("DB Created");
        

    }
}