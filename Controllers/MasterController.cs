using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeerthiveeduAPI.Data;
using KeerthiveeduAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KeerthiveeduAPI.Controllers
{
    
    public class MasterController : BaseApiController
    {
        private readonly DataContext context;
        

        public MasterController(DataContext context)
        {
            this.context = context;
            
        }

        [HttpGet("familygroups")]
        public async Task <ActionResult<IEnumerable<FamilyGroup>>> GetfamilyGroup()
        {
            List<FamilyGroup> familyList = new List<FamilyGroup>();
            familyList = await context.FamilyGroups.ToListAsync();
             FamilyGroup familygroup = new FamilyGroup
            {
                Id = 0,
                Name = "Select Family Group",
                IsActive = false
            };
            familyList.Insert(0,familygroup);
            return familyList;
        }

    }
}