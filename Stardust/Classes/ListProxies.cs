using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardust.Classes
{
    public class ProxyList
    {
        public int Count { get; set; }

        public string Next { get; set; }

        public string Previous { get; set; }

        public Result[] results { get; set; }
    }

    public class Result
    {
        public string username { get; set; }
        public string password { get; set; }
        public string proxy_address { get; set; }
        public Ports ports { get; set; }
        public bool valid { get; set; }
        public DateTime last_verification { get; set; }
        public string country_code { get; set; }
        public float country_code_confidence { get; set; }
    }

    public class Ports
    {
        public string http { get; set; }
        public string socks5 { get; set; }
    }
}
