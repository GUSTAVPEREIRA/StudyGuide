using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StudyGuide.Infra.Data;
using StudyGuide.Initializer;
using System;

namespace StudyGuide
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServices();
            services.AddRepositories();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StudyGuide", Version = "v1" });
            });

            var sqlServer = Configuration.GetSection("ConnectionStrings:SQLServer").Value;
            var postgreSQL = Configuration.GetSection("ConnectionStrings:PostgreSQL").Value;

            if (string.IsNullOrEmpty(sqlServer.Trim()) && string.IsNullOrEmpty(postgreSQL.Trim()))
            {
                throw new Exception("Por favor, configure o acesso ao banco de dados!");
            }

            services.AddDbContext<ApplicationContext>(options =>
            {
                if (!string.IsNullOrEmpty(sqlServer))
                {
                    options.UseSqlServer(sqlServer);
                }
                else
                {
                    options.UseNpgsql(postgreSQL);
                }
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StudyGuide v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}