using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace StudyGuide.Infra.Data
{
    public static class DependencyInjectable
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var sqlServer = configuration.GetSection("ConnectionStrings:SQLServer").Value;
            var postgreSQL = configuration.GetSection("ConnectionStrings:PostgreSQL").Value;

            if (string.IsNullOrEmpty(sqlServer.Trim()) && string.IsNullOrEmpty(postgreSQL.Trim()))
            {
                throw new Exception("Por favor, configure o acesso ao banco de dados!");
            }

            if (!string.IsNullOrEmpty(sqlServer))
            {
                services.AddDbContext<ApplicationContext>(options =>
                {
                    options.UseSqlServer(sqlServer, b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
                });
            }
            else if(!string.IsNullOrEmpty(postgreSQL))
            {
                services.AddDbContext<ApplicationContext>(options =>
                {
                    options.UseNpgsql(postgreSQL, b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
                });
            }

            return services;
        }
    }
}