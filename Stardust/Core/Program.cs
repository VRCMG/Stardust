using Newtonsoft.Json;
using Stardust.Settings;
using Stardust.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stardust
{
    class Program
    {
        static string LoggedIn { get; set; }

        static void Main(string[] args)
        {
            List<string> ValidIds = new List<string>()
            {
                "day",
                "skeletal"
            };
            GlobalUtils.FetchProxies();
            Console.Title = "~✦ ✧ S t a r d u s t ✧ ✦~";
            Console.WriteLine(new WebClient().DownloadString("https://pastebin.com/raw/9qH5H5gZ"));
            ConsoleUtils.InputWrite("Enter ID");
            string id = Console.ReadLine();
            if (!ValidIds.Contains(id.ToLower()))
            {
                Console.Clear();
                Console.WriteLine(new WebClient().DownloadString("https://pastebin.com/raw/9qH5H5gZ"));
                ConsoleUtils.Error("Failed to authenticate");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                LoggedIn = id;
                Console.Clear();
                Console.WriteLine("\t\t\t" + "/ Checking Files /");
                Thread.Sleep(2000);
                if (File.Exists("Config.json"))
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\t" + "- Checking Files -");
                    Thread.Sleep(500);
                    if (File.Exists("Accounts.txt"))
                    {
                        Console.Clear();
                        Console.WriteLine("\t\t\t" + @"\ Finishing routine setup \");
                        Thread.Sleep(500);
                        Configuration.LoadConfiguration();
                        Console.Clear();
                        GlobalUtils.AuthCookies = File.ReadAllLines("Accounts.txt").ToList();
                        Console.Title = $"~✦ ✧ S t a r d u s t ✧ ✦~ - {LoggedIn}@stardust:~$ - ✦~ Bots: {File.ReadAllLines("Accounts.txt").Count()} ~✦ Proxies: {GlobalUtils.Proxies.Count()}";
                        Console.WriteLine(new WebClient().DownloadString("https://pastebin.com/raw/9qH5H5gZ"));
                        for (; ; )
                        {
                            ConsoleUtils.InputWrite(LoggedIn, ">");
                            string cmd = Console.ReadLine();
                            GlobalUtils.HandleCommand(cmd);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\t\t\t" + "- Running first time setup -");
                    Thread.Sleep(500);
                    File.WriteAllText("Config.json", JsonConvert.SerializeObject(new Config()));
                    Configuration.LoadConfiguration();
                    Console.Clear();
                    Console.WriteLine("\t\t\t" + @"\ Running first time setup \");
                    File.Create("Accounts.txt").Close();
                    Thread.Sleep(500);
                    Console.Clear();
                    GlobalUtils.AuthCookies = File.ReadAllLines("Accounts.txt").ToList();
                    Console.Title = $"~✦ ✧ S t a r d u s t ✧ ✦~ - {LoggedIn}@stardust:~$ - ✦~ Bots: {File.ReadAllLines("Accounts.txt").Count()} ~✦ Proxies: {GlobalUtils.Proxies.Count()}";
                    Console.WriteLine(new WebClient().DownloadString("https://pastebin.com/raw/9qH5H5gZ"));
                    for(; ;)
                    {
                        ConsoleUtils.InputWrite(LoggedIn, ">");
                        string cmd = Console.ReadLine();
                        GlobalUtils.HandleCommand(cmd);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
