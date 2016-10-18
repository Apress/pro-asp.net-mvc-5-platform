using System.Collections.Generic;
using System.Security.Claims;

namespace Users.Infrastructure {

    public static class LocationClaimsProvider {

        public static IEnumerable<Claim> GetClaims(ClaimsIdentity user) {
            List<Claim> claims = new List<Claim>();
            if (user.Name.ToLower() == "alice") {
                claims.Add(CreateClaim(ClaimTypes.PostalCode, "DC 20500"));
                claims.Add(CreateClaim(ClaimTypes.StateOrProvince, "DC"));
            } else {
                claims.Add(CreateClaim(ClaimTypes.PostalCode, "NY 10036"));
                claims.Add(CreateClaim(ClaimTypes.StateOrProvince, "NY"));
            }
            return claims;
        }

        private static Claim CreateClaim(string type, string value) {
            return new Claim(type, value, ClaimValueTypes.String, "RemoteClaims");
        }
    }
}
