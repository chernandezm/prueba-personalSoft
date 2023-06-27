using Prueba.Api.Model.DTO.Authentication;
using Prueba.Api.Model.DTO.ResponseServices;
using System.Threading.Tasks;

namespace Prueba.Api.Services.Invoker.Authentication
{
    public interface IAuthenticateUserInvoker
    {
        Task<ResponseServices<object>> Execute(UserDataCredencialDto dataCredencial);
    }
}
