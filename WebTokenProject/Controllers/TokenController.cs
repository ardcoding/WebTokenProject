using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTokenProject.Security;

namespace WebTokenProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
            
        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetToken()
        {
            Token token = TokenHandler.CreateToken(_configuration); 
            return Ok(token);
        }
        [HttpGet("TokenValidation")]
        public bool TokenValidation(string token)
        {
           bool isValid = TokenValidate.TokenValidation(token, _configuration);
            return isValid;
        }
    }
}
