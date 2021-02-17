using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeerthiveeduAPI.Entities
{
    public class UserRights
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public AppUser AppUser { get; set; }
        public int RightsId { get; set; }
        public Rights Rights { get; set; }
        public bool IsActive { get; set; }
    }
}
