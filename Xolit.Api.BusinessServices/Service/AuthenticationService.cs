using System.Threading.Tasks;
using Xolit.Api.Model.Dto.Authentication;
using Xolit.Api.Model.DTO.ResponseServices;
using Xolit.Api.Services.Command.Authentication;
using Xolit.Api.Services.Invoker.Authentication;
using Xolit.Api.Services.Service;

namespace Xolit.Api.BusinessServices.Service
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
            return this.createTokenCommand.CreateToken();
        }

        public async Task<ResponseServices<object>> SignInUser(UserDataCredencialDto dataCredencial)
        {
            return await this.authenticateUserInvoker.Execute(dataCredencial);
        }
    }
}
