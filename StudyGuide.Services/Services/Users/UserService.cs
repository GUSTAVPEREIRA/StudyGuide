using AutoMapper;
using StudyGuide.Cryptographic;
using StudyGuide.DTO.User;
using StudyGuide.Extensions.Exceptions;
using StudyGuide.Infra.Repositories.IRepositories.Users;
using StudyGuide.Model.Users;
using StudyGuide.Services.IServices.Users;
using System.Net;

namespace StudyGuide.Services.Services.Users
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserDTO CreateUser(UserDTO userDTO)
        {
            var user = _mapper.Map<UserDTO, User>(userDTO);

            if (_userRepository.VerifyIfUserExist(user.Username))
            {
                throw new APIException("Este username já está em uso!", HttpStatusCode.BadRequest);
            }

            _userRepository.Save(user);
            userDTO.Id = user.Id;
            userDTO.Password = "";

            return userDTO;
        }

        public UserDTO GetUserByUsernameAndPassword(string username, string password)
        {
            var result = _userRepository.GetUserByUsernameAndPassword(username);

            if (result == null)
            {
                throw new APIException("Senha ou Username inválido!", HttpStatusCode.NotFound);
            }

            var validPassowrd = new PBKDF2().Verify(password, result.Password);
            var userDTO = _mapper.Map<User, UserDTO>(result);

            if (!validPassowrd)
            {
                throw new APIException("Senha ou Username inválido!", HttpStatusCode.Unauthorized);
            }

            userDTO.Password = "";

            return userDTO;
        }
    }
}