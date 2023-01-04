using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController
    {
        private readonly DataContext _context;
        public BuggyController(DataContext context)
        {
            _context = context;
            
        }
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret(){
            return "somthing secret";
        }
        [HttpGet("not-found")]
        public ActionResult<AppUserClass> GetNotFound(){
            var thing=_context.Users.Find(-1);
            if(thing==null) return GetNotFound();
            return thing;
        }
        [HttpGet("server-error")]
        public ActionResult<string> GetserverError()
        {
            
            var thing=_context.Users.Find(-1);
            var thingtoReturn=thing.ToString();
            return thingtoReturn;
            
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return  "this was a bad requst";
        }
    }
}