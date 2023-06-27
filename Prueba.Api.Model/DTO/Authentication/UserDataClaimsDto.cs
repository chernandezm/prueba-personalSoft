using System.Collections.Generic;

namespace Prueba.Api.Model.DTO.Authentication
{
    public class UserDataClaimsDto
    {
        public string UserId { get; set; }
        public IEnumerable<UserClaim> Claims { get; set; }
    }
}
