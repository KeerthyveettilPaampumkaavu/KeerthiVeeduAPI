using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KeerthiveeduAPI.Entities
{
    [Table("Photos")]
    public class Photo
    {
        public long Id { get; set; }
        public string Url { get; set; }
        
    }
}
