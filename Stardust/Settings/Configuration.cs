using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardust.Settings
{
    public static class Configuration
    {
        public static Config _Config { get; set; }

        public static void LoadConfiguration() {
            _Config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("Config.json"));
        }

        public static void SaveConfiguration() {
            File.WriteAllText("Config.json", JsonConvert.SerializeObject(_Config, Formatting.Indented));
        }
    }
}
