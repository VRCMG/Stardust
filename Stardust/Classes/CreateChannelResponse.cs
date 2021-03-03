using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardust.Classes
{

    public class CreateChannelResponse
    {
        public string id { get; set; }
        public int type { get; set; }
        public object last_message_id { get; set; }
        public Recipient[] recipients { get; set; }
    }

    public class Recipient
    {
        public string id { get; set; }
        public string username { get; set; }
        public string avatar { get; set; }
        public string discriminator { get; set; }
        public int public_flags { get; set; }
    }

}
