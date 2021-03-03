using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardust.Classes
{
    public class DustProxy
    {
        public string IP { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Port { get; set; }

        public DustProxy(string ip, string username, string password, string port)
        {
            IP = ip;
            Username = username;
            Password = password;
            Port = port;
        }
    }
}
