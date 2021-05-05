using Microsoft.Extensions.DependencyInjection;
using StudyGuide.Infra.Repositories.IRepositories.Users;
using StudyGuide.Infra.Repositories.Repositories.Users;

namespace StudyGuide.Initializer
{
    public static class RepositoriesRegister
    {
        public static void AddRepositories(this IServiceCollection serviceColletion)
        {
            serviceColletion.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
