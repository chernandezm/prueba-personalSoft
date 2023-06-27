using Prueba.Api.Model.DTO.Authentication;

namespace Prueba.Api.Services.Command.Authentication
{
    public interface IGenerateTokenCommand
    {
        string Execute(UserDataClaimsDto userDataClaims);
    }
}
