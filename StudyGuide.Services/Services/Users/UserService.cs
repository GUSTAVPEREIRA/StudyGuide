using AutoMapper;
using StudyGuide.DTO.User;
using StudyGuide.Infra.Repositories.IRepositories.Users;
using StudyGuide.Model.Users;
using StudyGuide.Services.IServices.Users;

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
            _userRepository.Save(user);
            userDTO.Id = user.Id;
            userDTO.Password = "";

            return userDTO;
        }
    }
}
