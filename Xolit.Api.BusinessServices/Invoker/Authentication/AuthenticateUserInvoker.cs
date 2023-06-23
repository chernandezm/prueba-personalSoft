using System.Threading.Tasks;
using Xolit.Api.Model.Dto.Authentication;
using Xolit.Api.Model.DTO.ResponseServices;
using Xolit.Api.Services.Command.Authentication;

namespace Xolit.Api.Services.Invoker.Authentication
{
    public class AuthenticateUserInvoker : IAuthenticateUserInvoker
    {
        private readonly IValidateUserCommand validateUserInvoker;
        private readonly IGenerateTokenCommand generateTokenInvoker;

        public AuthenticateUserInvoker(IValidateUserCommand validateUserInvoker, IGenerateTokenCommand generateTokenInvoker)
        {
            this.validateUserInvoker = validateUserInvoker;
            this.generateTokenInvoker = generateTokenInvoker;
        }

        public async Task<ResponseServices<object>> Execute(UserDataCredencialDto dataCredencial)
        {
            UserDataClaimsDto dataClaimsUser = await this.validateUserInvoker.Execute(dataCredencial);
            string tokenAuthentication = this.generateTokenInvoker.Execute(dataClaimsUser);
            throw new System.NotImplementedException();
        }
    }
}
