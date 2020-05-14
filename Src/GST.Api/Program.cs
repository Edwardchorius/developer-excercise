using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GST.Persistence.Commands;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GST.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            InitializeData(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void InitializeData(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var commandContext = scope.ServiceProvider.GetService<ProductCommandContext>();
                    commandContext.Database.EnsureDeleted();
                    commandContext.Database.EnsureCreated();
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
        }
    }
}
