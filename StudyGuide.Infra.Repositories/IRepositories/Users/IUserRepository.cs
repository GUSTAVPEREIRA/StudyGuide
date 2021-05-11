using StudyGuide.Model.Users;

namespace StudyGuide.Infra.Repositories.IRepositories.Users
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserByUsernameAndPassword(string username);
        bool VerifyIfUserExist(string username);
    }
}