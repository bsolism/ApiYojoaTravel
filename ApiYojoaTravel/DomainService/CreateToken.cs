using ApiYojoaTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using ApiYojoaTravel.Interfaces;

namespace ApiYojoaTravel.DomainService
{
    public class CreateToken : ICreateToken
    {
      
        private readonly IConfiguration configuration;

        public CreateToken(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string CreateJWT(User user)
        {
            var secretKey = configuration["AppSettings:Key"];
            var key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(secretKey));
            var claims = new Claim[]{
                new Claim(ClaimTypes.Name, user.UserName, user.Email),
            };
            var signingCredentials = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256Signature
            );
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = signingCredentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
