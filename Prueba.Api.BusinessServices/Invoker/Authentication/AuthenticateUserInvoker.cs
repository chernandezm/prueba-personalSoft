using Prueba.Api.Model.DTO.Authentication;
using Prueba.Api.Model.DTO.ResponseServices;
using Prueba.Api.Services.Command.Authentication;
using System.Threading.Tasks;

namespace Prueba.Api.Services.Invoker.Authentication
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
