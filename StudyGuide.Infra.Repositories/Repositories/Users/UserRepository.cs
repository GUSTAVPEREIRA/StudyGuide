using StudyGuide.Infra.Data;
using StudyGuide.Infra.Repositories.IRepositories.Users;
using StudyGuide.Model.Users;

namespace StudyGuide.Infra.Repositories.Repositories.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(PostgresApplicationContext context)
        {
            Context = context;
        }
    }
}
