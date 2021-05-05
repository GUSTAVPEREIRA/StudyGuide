using Microsoft.Extensions.DependencyInjection;
using StudyGuide.Services.IServices.Users;
using StudyGuide.Services.Services.Users;

namespace StudyGuide.Initializer
{
    public static class ServiceRegister
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}