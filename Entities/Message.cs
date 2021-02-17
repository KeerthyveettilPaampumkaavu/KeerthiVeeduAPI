using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeerthiveeduAPI.Entities
{
    public class Message
    {
        public long Id { get; set; }
        public string Header { get; set; }
        public string Details { get; set; }
        public string UserId { get; set; }
        public DateTime MessageDttm { get; set; }

    }
}
