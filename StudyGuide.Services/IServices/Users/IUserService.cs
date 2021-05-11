using StudyGuide.DTO.User;

namespace StudyGuide.Services.IServices.Users
{
    public interface IUserService
    {
        public UserDTO CreateUser(UserDTO userDTO);
        public UserDTO GetUserByUsernameAndPassword(string username, string password);
    }
}
