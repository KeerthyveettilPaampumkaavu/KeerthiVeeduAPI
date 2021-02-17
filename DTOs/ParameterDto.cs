using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeerthiveeduAPI.DTOs
{
    public class ParameterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PrevId { get; set; }
        public string ParameterMasterName { get; set; }
        public string ShortCode { get; set; }
        public bool IsActive { get; set; }

    }
}
