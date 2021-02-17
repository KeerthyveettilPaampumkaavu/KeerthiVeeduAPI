using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeerthiveeduAPI.DTOs
{
    public class userDTO
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public bool isadmin { get; set; }
        public bool isverificationadmin { get; set; }
    }
}
