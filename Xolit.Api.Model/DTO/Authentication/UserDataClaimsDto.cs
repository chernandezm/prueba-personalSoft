using System.Collections.Generic;

namespace Xolit.Api.Model.Dto.Authentication
{
    public class UserDataClaimsDto
    {
        public string UserId { get; set; }
        public IEnumerable<UserClaim> Claims { get; set; }
    }
}
