using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeerthiveeduAPI.Entities
{
    public class Parameters
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PrevId { get; set; }
        public Parameters Header { get; set; }
        public string ShortCode { get; set; }
        public bool IsActive { get; set; }

    }
}
