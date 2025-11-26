using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SeleniumCAzure.Config
{
    public static class ConfigManager
    {
         private static ConfigReader configReader;

        static ConfigManager()
        {
            var baseConfig = File.ReadAllText("appsetting.json");
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string,string>>(baseConfig);
            string env = dictionary!["Env"];
            var config = File.ReadAllText($"appsetting.{env}.json");
            configReader = JsonConvert.DeserializeObject<ConfigReader>(config)!;
        }

        public static ConfigReader configR => configReader;
    }
}
