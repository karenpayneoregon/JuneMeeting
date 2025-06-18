
using ConfigurationLibrary;
using Serilog;
using Serilog.Events;
using TemplateExample.Data;
using TemplateExample.Models;

namespace TemplateExample;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        SerilogOperations.Setup(builder);
        
        builder.Host.UseSerilog();

        /*
         * The commented code is conventional which is not reusable
         */

        //builder.Services.AddDbContext<Context>(options =>
        //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        //        .LogTo(new DbContextToFileLogger().Log, [DbLoggerCategory.Database.Command.Name],
        //            LogLevel.Information));


        var connectionString = builder.Configuration.GetConnectionString(nameof(ConnectionStrings.DefaultConnection));
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException($"The connection string {nameof(ConnectionStrings.DefaultConnection)} is not configured.");
        }

        /*
         * The following centered on DbContextOptionsBuilder which has no good sample code
         * - Used ChatGPT to assist, see EntityFrameworkHelpers\ChatInstructions.md
         * - Since code is separated into a class project its reusable
         */
        builder.Services.AddDbContextPool<Context>(_ => { });
        var options = builder.Environment.IsDevelopment() ?
            ContextOptions.Development<Context>(connectionString) :
            ContextOptions.Production<Context>(connectionString);


        builder.Services.AddSingleton(options.Options);
        builder.Services.AddRazorPages();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapRazorPages()
           .WithStaticAssets();

        app.Run();
    }
}
