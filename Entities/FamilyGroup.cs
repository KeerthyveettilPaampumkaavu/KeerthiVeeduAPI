using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeerthiveeduAPI.Entities
{
    public class FamilyGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int FamilyTypeId { get; set; }
        public Parameters FamilyTypes { get; set; }

    }
}
