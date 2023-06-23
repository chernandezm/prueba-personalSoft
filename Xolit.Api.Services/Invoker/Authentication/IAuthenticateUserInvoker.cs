using System.Threading.Tasks;
using Xolit.Api.Model.Dto.Authentication;
using Xolit.Api.Model.DTO.ResponseServices;

namespace Xolit.Api.Services.Invoker.Authentication
{
    public interface IAuthenticateUserInvoker
    {
        Task<ResponseServices<object>> Execute(UserDataCredencialDto dataCredencial);
    }
}
