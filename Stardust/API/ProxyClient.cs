using Stardust.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Stardust.API
{
    public class ProxyClient
    {
        private HttpClient Client { get; set; }

        public ProxyClient()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.Proxy = GlobalUtils.GetRandomProxy();
            Client = new HttpClient(handler);
        }

        public async Task<bool> Ping(string url)
        {
            try
            {
                var response = await Client.GetAsync(url);
                return response.StatusCode == System.Net.HttpStatusCode.OK;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Apply()
        {
            try
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", new System.Random().Next(1, 99999).ToString()),
                    new KeyValuePair<string, string>("email", "asd@gmail.com"),
                    new KeyValuePair<string, string>("items", "200000"),
                    new KeyValuePair<string, string>("roblox", "test"),
                    new KeyValuePair<string, string>("robux", "0"),
                });
                var response = await Client.PostAsync("https://rbx.place/apply", formContent);
                return response.StatusCode == System.Net.HttpStatusCode.OK;
            }
            catch
            {
                return false;
            }
        }
    }
}
