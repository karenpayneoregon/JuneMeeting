using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
// Ensure this is included for Log.Logger and LoggerConfiguration

// Ensure this is included for LogEventLevel
namespace ConfigurationLibrary;

/// <summary>
/// Provides operations for configuring Serilog logging in an ASP.NET Core application.
/// </summary>
/// <remarks>
/// This class includes methods to set up logging configurations tailored to different environments.
/// For development environments, logs are written to the console with a minimum log level of Information.
/// For non-development environments, logs are written to a file with a rolling interval.
/// </remarks>
public class SerilogOperations
{
    /// <summary>
    /// Configures Serilog logging for the application based on the environment.
    /// </summary>
    /// <param name="builder">
    /// The <see cref="WebApplicationBuilder"/> used to configure the application's services and middleware.
    /// </param>
    /// <remarks>
    /// In development environments, logs are written to the console with a minimum level of Information.
    /// In non-development environments, logs are written to a file with a rolling interval.
    /// </remarks>
    public static void Setup(WebApplicationBuilder builder)
    {

        if (builder.Environment.IsDevelopment())
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .MinimumLevel.Information()
                .WriteTo.Console()
                .CreateLogger();
        }
        else
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .MinimumLevel.Information()
                .WriteTo.File(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles",
                        $"{DateTime.Now.Year}-{DateTime.Now.Month:d2}-{DateTime.Now.Day:d2}", "Log.txt"),
                    rollingInterval: RollingInterval.Infinite,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();

        }

    }
}
