using BusinessLogic.Helper.Interface;
using Microsoft.AspNetCore.Mvc;

namespace SentientGeeks_Test.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ILogin _login;
        public AuthController(ILogin login)
        {
            _login = login;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult authenticate(IFormCollection entityLogin)
        {
            string token = "";
            if (entityLogin != null)
            {
                if (_login.Authlogin(entityLogin, ref token))
                {
                    return Ok(new { token = token });

                }
                else
                    return Unauthorized();

            }
            else
                return Unauthorized();
        }

    }
}