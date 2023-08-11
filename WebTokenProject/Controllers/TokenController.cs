using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
        public IActionResult GetToken(int id, string username)
        {
            Token token = TokenHandler.CreateToken(id,username,_configuration); 
            return Ok(token);
        }
        [HttpGet("TokenValidation")]
        public List<Claim> TokenValidation(string token)
        {
            List<Claim> isValid = TokenValidate.TokenValidation(token, _configuration);
            return isValid;
        }
    }
}
