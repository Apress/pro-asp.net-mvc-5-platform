using System.Collections.Generic;
using System.Security.Claims;

namespace Users.Infrastructure {
    public class ClaimsRoles {

        public static IEnumerable<Claim> CreateRolesFromClaims(ClaimsIdentity user) {
            List<Claim> claims = new List<Claim>();
            if (user.HasClaim(x => x.Type == ClaimTypes.StateOrProvince
                        && x.Issuer == "RemoteClaims" && x.Value == "DC")
                    && user.HasClaim(x => x.Type == ClaimTypes.Role
                        && x.Value == "Employees")) {
                claims.Add(new Claim(ClaimTypes.Role, "DCStaff"));
            }
            return claims;
        }
    }
}
