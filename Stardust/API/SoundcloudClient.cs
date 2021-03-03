using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Stardust.API
{
    public class SoundcloudClient
    {
        private HttpClient Client { get; set; }

        public SoundcloudClient()
        {
            Client = new HttpClient();
        }
    }
}
