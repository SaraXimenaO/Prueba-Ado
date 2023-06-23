using Domain.Entities.Autenticacion;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Application.Auth
{
    public class Auth: IAuth
    {
        public IConfiguration Configuration { get; }
        public Auth(IConfiguration configuration)
        {
            Configuration = configuration;
        }

       

        public RespuestaAutenticacion GetToken(UserLogin userLogin)
        {
            var claims = new List<Claim>()
            {
                new Claim ("email", userLogin.Email)
            };

            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["LlaveJwt"]));
            var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);
            var expiracion = DateTime.Now.AddDays(1);

            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiracion, signingCredentials: creds);

            return new RespuestaAutenticacion()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiracion = expiracion,
            };

        }
    }
}
