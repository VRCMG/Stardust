using Newtonsoft.Json;
using Stardust.Classes;
using Stardust.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Stardust.API
{
    public class DiscordClient
    {
        private HttpClient Client { get; set; }

        private string Token { get; set; }

        public DiscordClient(string token)
        {
            Token = token;
            HttpClientHandler handler = new HttpClientHandler();
            handler.Proxy = GlobalUtils.GetRandomProxy();
            Client = new HttpClient(handler);
            Client.DefaultRequestHeaders.Add("Authorization", Token);
            Client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/0.0.309 Chrome/83.0.4103.122 Electron/9.3.5 Safari/537.36");
            Client.DefaultRequestHeaders.Add("X-Context-Properties", "eyJsb2NhdGlvbiI6IkpvaW4gR3VpbGQiLCJsb2NhdGlvbl9ndWlsZF9pZCI6Ijc1NjMwNjYxOTUxNTU3NjMyIiwibG9jYXRpb25fY2hhbm5lbF9pZCI6IjQ2ODkwNjA1MDcxNjY5NjU3NyIsImxvY2F0aW9uX2NoYW5uZWxfdHlwZSI6MH0=");
            Client.DefaultRequestHeaders.Add("X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjAuMC4zMDkiLCJvc192ZXJzaW9uIjoiMTAuMC4xODM2MyIsIm9zX2FyY2giOiJ4NjQiLCJjbGllbnRfYnVpbGRfbnVtYmVyIjo3NDAwOCwiY2xpZW50X2V2ZW50X3NvdXJjZSI6bnVsbH0=");
        }

        public async Task<bool> JoinServer(string invite)
        {
            try
            {
                if (invite.Contains("https://"))
                    invite = invite.Replace("https://", "");

                if (invite.Contains("http://"))
                    invite = invite.Replace("http://", "");

                if (invite.Contains("discord.gg/"))
                    invite = invite.Replace("discord.gg/", "");

                if (invite.Contains("discord.com/invite/"))
                    invite = invite.Replace("discord.com/invite/", "");

                var response = await Client.PostAsync($"https://discord.com/api/v8/invites/{invite}", null);
                return response.StatusCode == (System.Net.HttpStatusCode)204;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> LeaveServer(string id)
        {
            try
            {
                var response = await Client.DeleteAsync($"https://discord.com/api/v8/users/@me/guilds/{id}");
                return response.StatusCode == (System.Net.HttpStatusCode)204;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> SendMessage(string channelid, string message)
        {
            try
            {
                var response = await Client.PostAsync($"https://discord.com/api/v8/channels/{channelid}/messages", new StringContent(JsonConvert.SerializeObject(new Message() { content = message, nonce = null, tts = false }), Encoding.UTF8, "application/json"));
                return response.StatusCode == System.Net.HttpStatusCode.OK;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> React(string channelid, string messageid, string emote)
        {
            try
            {
                var response = await Client.PutAsync($"https://discord.com/api/v8/channels/{channelid}/messages/{messageid}/reactions/{HttpUtility.UrlEncode(emote)}/%40me", null);
                return response.StatusCode == (System.Net.HttpStatusCode)204;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ulong> CreateChannel(string userid)
        {
            try
            {
                var response = await Client.PostAsync("https://discord.com/api/v8/users/@me/channels", new StringContent("{\"recipients\":[\"" + userid + "\"]}", Encoding.UTF8, "application/json"));
                return Convert.ToUInt64(JsonConvert.DeserializeObject<CreateChannelResponse>(response.Content.ReadAsStringAsync().Result).id);
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Friend(string fulltag)
        {
            try
            {
                var response = await Client.PostAsync("https://discord.com/api/v8/users/@me/relationships", new StringContent(JsonConvert.SerializeObject(new AddUser() { username = fulltag.Split('#')[0], discriminator = Convert.ToInt32(fulltag.Split('#')[1]) }), Encoding.UTF8, "application/json"));
                return response.StatusCode == (System.Net.HttpStatusCode)204;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AcceptConditions(string guildid, string json)
        {
            try
            {
                var response = await Client.PutAsync($"https://discord.com/api/v8/guilds/{guildid}/requests/@me", new StringContent(json, Encoding.UTF8, "application/json"));
                return response.StatusCode == (System.Net.HttpStatusCode)201;
            }
            catch
            {
                return false;
            }
        }
    }
}
