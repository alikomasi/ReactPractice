using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var host= CreateHostBuilder(args).Build();
           using(var scope=host.Services.CreateScope())
           {
               var services=scope.ServiceProvider;
               try
               {
                   var Context=services.GetRequiredService<DataContext>();
                   Context.Database.Migrate();
               }
               catch (Exception ex)
               {
                   
                   var logger=services.GetRequiredService<Logger<Program>>();
                   logger.LogError(ex , "An Error accoured During Migration");
               }
           }
           host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
