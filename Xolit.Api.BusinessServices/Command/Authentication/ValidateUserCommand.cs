using System.Collections.Generic;
using System.Threading.Tasks;
using Xolit.Api.Model.Dto.Authentication;
using Xolit.Api.Services.Command.Authentication;

namespace Xolit.Api.BusinessServices.Command.Authentication
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
