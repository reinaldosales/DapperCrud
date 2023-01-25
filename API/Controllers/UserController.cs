using Domain.Interface;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Shared.Resources;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/v1")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] UserLoginModel model)
        {
            try
            {
                var user = _userService.RecoverUser(model.Username, model.Password);

                if (user is null)
                    return NotFound(new { Result = UserMsg.InvalidUser });

                var token = TokenService.GenerateToken(user);

                user.Password = String.Empty;

                return Ok(new { user = user.Username, token = token });
            }
            catch (Exception)
            {
                return BadRequest(new { Result = ApiMsg.AnErrorOccurred });
            }
        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser([FromBody] CreateUserModel model)
        {
            try
            {
                var user = _userService.RecoverUser(model.Username, model.Password);

                if (user is not null)
                    return BadRequest(new { Result = UserMsg.ExistingUser });

                user = _userService.CreateNewUser(model);

                return Ok(new { Result = string.Format(UserMsg.CreatedUser, user.Username) });
            }
            catch (Exception)
            {
                return BadRequest(new { Result = ApiMsg.AnErrorOccurred });
            }
        }
    }
}