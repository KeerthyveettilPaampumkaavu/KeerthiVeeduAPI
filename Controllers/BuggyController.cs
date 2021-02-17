using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeerthiveeduAPI.Data;
using KeerthiveeduAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KeerthiveeduAPI.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext context;

        public BuggyController(DataContext context)
        {
            this.context = context;
        }
        [Authorize]
         [HttpGet("Auth")]
         public ActionResult<string> GetSecret()
        {
            return "secret text";
        }
        [HttpGet("not-found")]
        public ActionResult<string> GetNotFound()
        {
            AppUser user = context.Users.Where(x=>x.Id==-1).FirstOrDefault();
            if (user == null) return NotFound();
            return Ok(user);
                
        }
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var thing = context.Users.Where(x=>x.Id==-1);
            var thingtoreturn = thing.ToString();
            return thingtoreturn;
        }
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This is a Bad Request");
        }
    }
}