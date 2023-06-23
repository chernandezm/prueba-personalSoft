using System.Threading.Tasks;
using Xolit.Api.Model.Dto.Authentication;
using Xolit.Api.Model.DTO.ResponseServices;

namespace Xolit.Api.Services.Service
{
    public interface IAuthenticationService
    {
        Task<ResponseServices<object>> SignInUser(UserDataCredencialDto dataCredencial);
        string GetToken();
    }
}
