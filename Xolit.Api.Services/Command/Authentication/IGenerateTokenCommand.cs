using Xolit.Api.Model.Dto.Authentication;

namespace Xolit.Api.Services.Command.Authentication
{
    public interface IGenerateTokenCommand
    {
        string Execute(UserDataClaimsDto userDataClaims);
    }
}
