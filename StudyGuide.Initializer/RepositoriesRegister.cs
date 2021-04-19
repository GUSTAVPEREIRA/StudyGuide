using Microsoft.Extensions.DependencyInjection;

namespace StudyGuide.Initializer
{
    public static class RepositoriesRegister
    {
        public static void AddRepositories(this IServiceCollection serviceColletion)
        {
            //serviceColletion.AddScoped<IRepository, Repository>();
        }
    }
}
