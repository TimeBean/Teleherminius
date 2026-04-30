using Hardware.Info;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Teleherminius.Application.Adapter;
using Teleherminius.Application.InformationBlock;
using Teleherminius.Core.Adapter;
using Teleherminius.Core.Repository;
using Teleherminius.Infrastructure;
using Teleherminius.Infrastructure.Repository;

namespace Teleherminius.Presentation.Collector
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .UseSerilog((context, config) => { config.WriteTo.Console(); })
                .ConfigureServices((context, services) =>
                {
                    var connectionString =
                        context.Configuration.GetConnectionString("DefaultConnection");
                    
                    services.AddSingleton<HardwareInfo>();
                    services.AddSingleton<IHardwareInformationAdapter, HardwareInfoAdapter>();
                    services.AddMemoryCache();
                    services.AddSingleton<IInformationBlockRepository, DatabaseInformationBlockRepository>();
                    services.AddMediatR(cfg =>
                        cfg.RegisterServicesFromAssembly(typeof(CreateCommand).Assembly));
                    services.AddDbContext<AppDbContext>(options =>
                        options.UseMySql(
                            connectionString,
                            ServerVersion.AutoDetect(connectionString)
                        ));
                    services.AddHostedService<App>();
                })
                .Build();

            host.Run();
        }
    }
}