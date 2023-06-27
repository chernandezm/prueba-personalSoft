using Prueba.Api.Model.DTO.Authentication;
using Prueba.Api.Model.DTO.ResponseServices;
using System.Threading.Tasks;

namespace Prueba.Api.Services.Service
{
    public interface IAuthenticationService
    {
        Task<ResponseServices<object>> SignInUser(UserDataCredencialDto dataCredencial);
        string GetToken();
    }
}
