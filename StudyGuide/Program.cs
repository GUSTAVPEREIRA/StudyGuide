using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StudyGuide.Infra.Data;
using System;

namespace StudyGuide
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var configuration = services.GetRequiredService<IConfiguration>();
                    var sqlServer = configuration.GetSection("ConnectionStrings:SQLServer").Value;
                    var postgreSQL = configuration.GetSection("ConnectionStrings:PostgreSQL").Value;

                    if (!string.IsNullOrEmpty(sqlServer))
                    {
                        var context = services.GetRequiredService<ApplicationContext>();
                        context.Database.Migrate();
                    }
                    else
                    {
                        var context = services.GetRequiredService<ApplicationContext>();
                        context.Database.Migrate();
                    }
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Ocorreu um erro na migração ou alimentação de dados");
                }
            }

            host.Run();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
