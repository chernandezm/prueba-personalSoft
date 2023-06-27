using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Prueba.Api.Model.DTO.Authentication;
using Prueba.Api.Model.Model.Configuration;
using Prueba.Api.Services.Command.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

namespace Prueba.Api.BusinessServices.Command.Authentication
{
    public class GenerateTokenCommand : IGenerateTokenCommand
    {
        private readonly TokenConfiguration configurationToken;

        public GenerateTokenCommand(IOptions<TokenConfiguration> configurationToken)
        {
            this.configurationToken = configurationToken.Value;
        }

        public string Execute(UserDataClaimsDto userDataClaims)
        {
            List<Claim> claims = new List<Claim>(capacity: userDataClaims.Claims.Count());
            foreach (UserClaim claim in userDataClaims.Claims)
            {
                claims.Add(new Claim(claim.ClaimsName, claim.ClaimsValue));
            }

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationToken.Secrect));
            SigningCredentials creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            JwtSecurityToken token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddSeconds(configurationToken.ExpirationTime),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}