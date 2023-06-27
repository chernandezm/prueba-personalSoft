using Prueba.Api.Model.DTO.Authentication;
using Prueba.Api.Services.Command.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prueba.Api.BusinessServices.Command.Authentication
{
    public class ValidateUserCommand : IValidateUserCommand
    {
        public async Task<UserDataClaimsDto> Execute(UserDataCredencialDto userDataCredencial)
        {
            UserDataClaimsDto user = new UserDataClaimsDto() { Claims = new List<UserClaim>() { new UserClaim() { ClaimsName = "VerRoles", ClaimsValue = "PolicyGetRoles" }, new UserClaim() { ClaimsName = "CreateRoles", ClaimsValue = "PolicyCreateRoles" } } };
            return user;
        }
    }
}
