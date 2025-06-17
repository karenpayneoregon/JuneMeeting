using System.Diagnostics;
using EntityCoreFileLogger;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkHelpers;
public class ContextOptions
{

    public static DbContextOptionsBuilder<T> Development<T>(string connectionString) where T : DbContext
    {   

        var options = new DbContextOptionsBuilder<T>()
            .UseSqlServer(connectionString)
            .LogTo(message => Debug.WriteLine(message), LogLevel.Information)
            .EnableSensitiveDataLogging();

        return options;

    }

    public static DbContextOptionsBuilder<T> Production<T>(string connectionString) where T : DbContext
    {

        var options = new DbContextOptionsBuilder<T>()
            .UseSqlServer(connectionString)
            .LogTo(new DbContextToFileLogger().Log, [DbLoggerCategory.Database.Command.Name], 
                LogLevel.Information);

        return options;

    }
}