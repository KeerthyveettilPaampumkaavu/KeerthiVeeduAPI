using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeerthiveeduAPI.Entities
{
    public class RitualBookingDetail
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int RitualId { get; set; }
        public Ritual Ritual { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }
    }
}
