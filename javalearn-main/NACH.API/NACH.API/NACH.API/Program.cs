using Microsoft.AspNetCore.Server.Kestrel.Core;
using NACH.DAL.Data;
using NACH.API;

using NACH.API.Services;
using System.Runtime.InteropServices;
using NACH.API.Services;


public class Program
{
    public static void Main(string[] args)
    {

        var host = CreateHostBuilder(args).Build();

        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();
                var functional = services.GetRequiredService<IFunctional>();

                //DbInitializer.Initialize(context, functional).Wait();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while seeding the database.");
            }
        }
        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);


        IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args);

        if (!isWindows)
        {
            hostBuilder.ConfigureServices((context, services) => {
                services.Configure<KestrelServerOptions>(context.Configuration.GetSection("Kestrel"));
            });
        }

        hostBuilder.ConfigureWebHostDefaults(webBuilder => {
            webBuilder.ConfigureLogging((context, logging) => {
                logging.AddConfiguration(context.Configuration.GetSection("Logging"));
                logging.AddConsole();
                logging.AddDebug();
            });

            //webBuilder.UseIISIntegration();
            webBuilder.UseStartup<Startup>();

            /**************************************************************/
            //Server Setup
            /**************************************************************/

            //webBuilder.UseKestrel(opts => {
            //    opts.ListenAnyIP(5001);
            //});
        });
        return hostBuilder;
    }
}