using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Users.Models {

    public enum Cities {
        LONDON, PARIS, CHICAGO
    }

    public enum Countries {
        NONE, UK, FRANCE, USA
    }

    public class AppUser : IdentityUser {
        public Cities City { get; set; }
        public Countries Country { get; set; }

        public void SetCountryFromCity(Cities city) {
            switch (city) {
                case Cities.LONDON:
                    Country = Countries.UK;
                    break;
                case Cities.PARIS:
                    Country = Countries.FRANCE;
                    break;
                case Cities.CHICAGO:
                    Country = Countries.USA;
                    break;
                default:
                    Country = Countries.NONE;
                    break;
            }
        }
    }
}
