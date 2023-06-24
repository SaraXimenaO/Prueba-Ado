using Application.Auth;
using Application.Recaudos;
using Domain.Entities;
using Domain.Entities.Autenticacion;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Prueba_Ado.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {

        public UserManager<IdentityUser> UserManager { get; }
        public IConfiguration Configuration { get; }
        public IAuth _Auth { get; }
        public SignInManager<IdentityUser> SignInManager { get; }

        public LoginController(UserManager<IdentityUser> userManager, IConfiguration configuration, IAuth auth, SignInManager<IdentityUser>  signInManager )
        {
            UserManager = userManager;
            Configuration = configuration;
            _Auth = auth;
            SignInManager = signInManager;
        }

        [HttpPost("CreateAcount")]
        public async Task<ActionResult<RespuestaAutenticacion>> CreateAcount(UserLogin login)
        {
            var usuario = new IdentityUser { UserName = login.Email, Email = login.Email };
            var result = await UserManager.CreateAsync(usuario, login.PassWord);
            if (result.Succeeded)
            {
                return _Auth.GetToken(login);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost]
        public async Task<ActionResult<RespuestaAutenticacion>> login(UserLogin userLogin)
        {
            var result = await SignInManager.PasswordSignInAsync(userLogin.Email, userLogin.PassWord, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return _Auth.GetToken(userLogin);
            }
            else
            {
                return  BadRequest("Login incorrecto");
            }
        }

       
    }
}
