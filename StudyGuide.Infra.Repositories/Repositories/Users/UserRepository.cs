using StudyGuide.Infra.Data;
using StudyGuide.Infra.Repositories.IRepositories.Users;
using StudyGuide.Model.Users;
using System.Linq;

namespace StudyGuide.Infra.Repositories.Repositories.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
            Context = context;
        }

        public User GetUserByUsernameAndPassword(string username)
        {
            var result = Context.TbUsers
                .Where(w => w.Username == username).FirstOrDefault();

            return result;
        }

        public bool VerifyIfUserExist(string username)
        {
            var result = Context.TbUsers.Where(w => w.Username == username).Any();

            return result;
        }
    }
}