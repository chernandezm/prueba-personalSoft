using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xolit.Api.Services.Command.Authentication;

namespace Xolit.Api.BusinessServices.Command.Authentication
{
    public class CreateTokenCommand: ICreateTokenCommand
    {
        public string CreateToken()
        {
            List<Claim> claims = new List<Claim>();
            // claims.Add(new Claim("PolicyGetRoles", "VerRoles"));
            // claims.Add(new Claim("PolicyCreateRoles", "PolicyCreateRoles"));
            claims.Add(new Claim("VerRoles", "PolicyGetRoles"));
            claims.Add(new Claim("CreateRoles", "PolicyCreateRoles"));

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("PDv7DrqznYL6nv7DrqzjnQYO9JxIsWdcjnQYL6nu0f"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: System.DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
