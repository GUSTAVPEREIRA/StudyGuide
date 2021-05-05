using Microsoft.AspNetCore.Mvc;
using StudyGuide.DTO.User;
using StudyGuide.Services.IServices.Users;

namespace StudyGuide.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [Route("create")]
        [HttpPost]
        public ActionResult<dynamic> CreateUser(UserDTO userDTO)
        {
            var result = _userService.CreateUser(userDTO);

            return new OkObjectResult(new
            {
                User = result,
                Message = "Usuário criado com sucesso!"
            });
        }
    }
}
