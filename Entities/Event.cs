using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeerthiveeduAPI.Entities
{
    public class Event
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDttm { get; set; }
        public DateTime EndDttm { get; set; }
        public ICollection<Photo> Photos{get;set;}

    }
}
