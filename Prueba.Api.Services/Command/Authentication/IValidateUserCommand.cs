using Prueba.Api.Model.DTO.Authentication;
using System.Threading.Tasks;

namespace Prueba.Api.Services.Command.Authentication
{
    public interface IValidateUserCommand
    {
        Task<UserDataClaimsDto> Execute(UserDataCredencialDto userDataCredencial);
    }
}
