using System.Threading.Tasks;
using Xolit.Api.Model.Dto.Authentication;

namespace Xolit.Api.Services.Command.Authentication
{
    public interface IValidateUserCommand
    {
        Task<UserDataClaimsDto> Execute(UserDataCredencialDto userDataCredencial);
    }
}
