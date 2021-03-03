using Stardust.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Stardust.API
{
    public class AnonClient
    {
        private HttpClient Client { get; set; }

        public AnonClient()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.Proxy = GlobalUtils.GetRandomProxy();
            Client = new HttpClient(handler);
            Client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36");
        }

        public async Task<bool> UploadVideoAsync(string url, string file)
        {
            try
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("upload_option", "url"),
                    new KeyValuePair<string, string>("url", url),
                    new KeyValuePair<string, string>("action", "upload_file"),
                    new KeyValuePair<string, string>("filename", file.Split('.')[0]),
                    new KeyValuePair<string, string>("format", "json"),
                    new KeyValuePair<string, string>("mode", "async"),
                });
                var response = await Client.PostAsync("https://anonvideos.com/upload-video/?mode=async&format=json&action=upload_file", formContent);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    formContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("title", "Pwned by Retard Sec - Skeletal"),
                        new KeyValuePair<string, string>("description", "fucking cp lovers <3 - operation stardust"),
                        new KeyValuePair<string, string>("filter", ""),
                        new KeyValuePair<string, string>("tags", "sex"),
                        new KeyValuePair<string, string>("screenshot", ""),
                        new KeyValuePair<string, string>("function", "get_block"),
                        new KeyValuePair<string, string>("block_id", "video_edit_video_edit"),
                        new KeyValuePair<string, string>("file", file),
                        new KeyValuePair<string, string>("file_hash", file.Split('.')[0]),
                        new KeyValuePair<string, string>("format", "json"),
                        new KeyValuePair<string, string>("mode", "async"),
                    });
                    response = await Client.PostAsync("https://anonvideos.com/upload-video/", formContent);
                    return response.StatusCode == System.Net.HttpStatusCode.OK;
                }
                else
                    return false;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Dislike(string url, string videoid)
        {
            try
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("upload_option", "url"),
                    new KeyValuePair<string, string>("video_id", videoid),
                    new KeyValuePair<string, string>("action", "rate"),
                    new KeyValuePair<string, string>("playlist_id", ""),
                    new KeyValuePair<string, string>("format", "json"),
                    new KeyValuePair<string, string>("mode", "async"),
                    new KeyValuePair<string, string>("vote", "0"),
                });
                var response = await Client.PostAsync(url, formContent);
                return response.StatusCode == System.Net.HttpStatusCode.OK;
            }
            catch
            {
                return false;
            }
        }
    }
}
