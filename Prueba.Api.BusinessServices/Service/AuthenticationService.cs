using Prueba.Api.Model.DTO.Authentication;
using Prueba.Api.Model.DTO.ResponseServices;
using Prueba.Api.Services.Command.Authentication;
using Prueba.Api.Services.Invoker.Authentication;
using Prueba.Api.Services.Service;
using System.Threading.Tasks;

namespace Prueba.Api.BusinessServices.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticateUserInvoker authenticateUserInvoker;
        private readonly ICreateTokenCommand createTokenCommand;

        public AuthenticationService(IAuthenticateUserInvoker authenticateUserInvoker, ICreateTokenCommand createTokenCommand)
        {
            this.authenticateUserInvoker = authenticateUserInvoker;
            this.createTokenCommand = createTokenCommand;
        }

        public string GetToken()
        {
            return createTokenCommand.CreateToken();
        }

        public async Task<ResponseServices<object>> SignInUser(UserDataCredencialDto dataCredencial)
        {
            return await authenticateUserInvoker.Execute(dataCredencial);
        }
    }
}
