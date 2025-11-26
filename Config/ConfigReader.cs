using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCAzure.Config
{
    public class ConfigReader
    {
        public  string ?url { get; set; }
        public  string ?username { get; set; }
        public  string ?password { get; set; }
        public  string ?browser { get; set; }
    }
}
