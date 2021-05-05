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
            services.AddDbContext<PostgresApplicationContext>(options =>
            {
                var sqlServer = configuration.GetSection("ConnectionStrings:SQLServer").Value;
                var postgreSQL = configuration.GetSection("ConnectionStrings:PostgreSQL").Value;

                if (string.IsNullOrEmpty(sqlServer.Trim()) && string.IsNullOrEmpty(postgreSQL.Trim()))
                {
                    throw new Exception("Por favor, configure o acesso ao banco de dados!");
                }

                if (!string.IsNullOrEmpty(sqlServer))
                {
                    options.UseSqlServer(sqlServer, b => b.MigrationsAssembly(typeof(PostgresApplicationContext).Assembly.FullName));
                }
                else
                {
                    options.UseNpgsql(postgreSQL, b => b.MigrationsAssembly(typeof(PostgresApplicationContext).Assembly.FullName));
                }
            });

            return services;
        }
    }
}