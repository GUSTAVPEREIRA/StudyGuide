using Microsoft.Extensions.DependencyInjection;
using StudyGuide.Services.IServices.User;
using StudyGuide.Services.Services.User;

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