using System.Configuration;

namespace ConfigFiles.Infrastructure {

    public class PlaceSection : ConfigurationSection {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(PlaceCollection))]
        public PlaceCollection Places {
            get { return (PlaceCollection)base[""]; }
        }

        [ConfigurationProperty("default")]
        public string Default {
            get { return (string)base["default"]; }
            set { base["default"] = value; }
        }
    }
}
