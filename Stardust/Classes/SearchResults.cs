using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardust.Classes
{

    public class SearchResult
    {
        public int total_results { get; set; }
        public ResultMessage[][] messages { get; set; }
        public string analytics_id { get; set; }
    }

    public class ResultMessage
    {
        public string id { get; set; }
        public int type { get; set; }
        public string content { get; set; }
        public string channel_id { get; set; }
        public Author author { get; set; }
        public object[] attachments { get; set; }
        public Embed[] embeds { get; set; }
        public object[] mentions { get; set; }
        public object[] mention_roles { get; set; }
        public bool pinned { get; set; }
        public bool mention_everyone { get; set; }
        public bool tts { get; set; }
        public DateTime timestamp { get; set; }
        public object edited_timestamp { get; set; }
        public int flags { get; set; }
        public string webhook_id { get; set; }
        public bool hit { get; set; }
    }

    public class Author
    {
        public bool bot { get; set; }
        public string id { get; set; }
        public string username { get; set; }
        public object avatar { get; set; }
        public string discriminator { get; set; }
    }

    public class Embed
    {
        public string type { get; set; }
        public string url { get; set; }
        public Thumbnail thumbnail { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int color { get; set; }
        public Author1 author { get; set; }
        public Provider provider { get; set; }
        public Video video { get; set; }
    }

    public class Thumbnail
    {
        public string url { get; set; }
        public string proxy_url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Author1
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Provider
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Video
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

}
