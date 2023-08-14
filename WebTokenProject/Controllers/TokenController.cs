using BusinessServices.Layer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserDb.Entities;
using WebTokenProject.Security;

namespace WebTokenProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserBusiness _userBusiness;

        public TokenController(IConfiguration configuration, IUserBusiness userBusiness)
        {
            _configuration = configuration;
            _userBusiness = userBusiness;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetToken(string username, string password)
        {
            var user = await _userBusiness.GetUser(username, password);
            if (user== null)
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }
            var id = user.Id;
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
