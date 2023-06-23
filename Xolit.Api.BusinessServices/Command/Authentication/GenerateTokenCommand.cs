using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using Xolit.Api.Model.Dto.Authentication;
using Xolit.Api.Model.Dto.Configuration;
using Xolit.Api.Repository.Entity;
using Xolit.Api.Repository.Repository.Generic.Interface;
using Xolit.Api.Services.Command.Authentication;

namespace Xolit.Api.BusinessServices.Command.Authentication
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