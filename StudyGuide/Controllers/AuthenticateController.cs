using Microsoft.AspNetCore.Mvc;
using StudyGuide.DTO.User;
using StudyGuide.Extensions.Exceptions;
using StudyGuide.Services.IServices.Token;
using StudyGuide.Services.IServices.Users;

namespace StudyGuide.API.Controllers
{    
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokenService"></param>
        /// <param name="userService"></param>
        public AuthenticateController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [HttpPost] 
        [Route("")]
        public ActionResult<dynamic> Authenticate(UserLoginDTO userDTO)
        {
            try
            {
                var userActivated = _userService.GetUserByUsernameAndPassword(userDTO.Username, userDTO.Password);
                var token = _tokenService.GenerateToken(userActivated);                

                return new OkObjectResult(new
                {
                    User = userActivated,
                    BearerToken = token,
                    Message = "Usuário autenticado!"
                });
            }
            catch (APIException ex)
            {
                return new BadRequestObjectResult(new
                {
                    ex.Message,
                    Code = ex.StatusCode
                });
            }
            

        }
    }
}
