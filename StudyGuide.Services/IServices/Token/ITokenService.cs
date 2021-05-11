using StudyGuide.DTO.User;

namespace StudyGuide.Services.IServices.Token
{
    public interface ITokenService
    {
        public string GenerateToken(UserDTO user);
    }
}