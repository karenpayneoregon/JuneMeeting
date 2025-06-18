using System.Diagnostics;
using EntityCoreFileLogger;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkHelpers;
public class ContextOptions
{

    /// <summary>
    /// Configures and returns a <see cref="DbContextOptionsBuilder{T}"/> for development environments.
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="DbContext"/>.</typeparam>
    /// <param name="connectionString">The connection string to the database.</param>
    /// <returns>A configured <see cref="DbContextOptionsBuilder{T}"/> instance with development-specific settings.</returns>
    public static DbContextOptionsBuilder<T> Development<T>(string connectionString) where T : DbContext
    {   

        var options = new DbContextOptionsBuilder<T>()
            .UseSqlServer(connectionString)
            .LogTo(message => Debug.WriteLine(message), LogLevel.Information)
            .EnableSensitiveDataLogging();

        return options;

    }

    /// <summary>
    /// Configures and returns a <see cref="DbContextOptionsBuilder{T}"/> for staging environments.
    /// Uses the same configuration as the Development method.
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="DbContext"/>.</typeparam>
    /// <param name="connectionString">The connection string to the database.</param>
    /// <returns>A configured <see cref="DbContextOptionsBuilder{T}"/> instance with staging-specific settings.</returns>
    public static DbContextOptionsBuilder<T> Staging<T>(string connectionString) where T : DbContext 
        => Development<T>(connectionString);

    /// <summary>
    /// Configures and returns a <see cref="DbContextOptionsBuilder{T}"/> for production environments.
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="DbContext"/>.</typeparam>
    /// <param name="connectionString">The connection string to the database.</param>
    /// <returns>A configured <see cref="DbContextOptionsBuilder{T}"/> instance with production-specific settings.</returns>
    public static DbContextOptionsBuilder<T> Production<T>(string connectionString) where T : DbContext
    {

        var options = new DbContextOptionsBuilder<T>()
            .UseSqlServer(connectionString)
            .LogTo(new DbContextToFileLogger().Log, [DbLoggerCategory.Database.Command.Name], 
                LogLevel.Information);

        return options;

    }
}