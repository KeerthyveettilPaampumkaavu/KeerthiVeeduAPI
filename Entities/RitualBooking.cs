using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeerthiveeduAPI.Entities
{
    public class RitualBooking
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public AppUser User { get; set; }
        public DateTime RitualDate{get; set; }
        public DateTime BookedDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }
        public int StatusId { get; set; }
        public Parameters Status { get; set; }
    }
}
