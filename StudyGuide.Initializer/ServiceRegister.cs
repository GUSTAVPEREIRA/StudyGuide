using Microsoft.Extensions.DependencyInjection;

namespace StudyGuide.Initializer
{
    public static class ServiceRegister
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<Services.IServices.Users.IUserService, Services.Services.Users.UserService>();
            services.AddScoped<Services.IServices.Token.ITokenService, Services.Services.Token.TokenService>();
        }
    }
}