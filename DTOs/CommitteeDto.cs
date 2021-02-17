using KeerthiveeduAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeerthiveeduAPI.DTOs
{
    public class CommitteeDto
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public AppUser User { get; set; }
        public int MemberPositionId { get; set; }
        public Parameters MemberPosition { get; set; }
        public string PhotoUrl { get; set; }
        
    }
}
