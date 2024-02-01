using kayahome_backend.Contexts;
using kayahome_backend.Contexts.Sets;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace kayahome_backend.Controllers
{
    public class KayaHomeController : BaseController
    {
        [HttpGet]
        public IActionResult Status()
        {
            return Ok();
        }

        [Route("ping")]
        [HttpGet]
        public IActionResult Ping()
        {
            return CreatedAtRoute(201, Request.GetDisplayUrl());
        }

        [Route("mongotest")]
        [HttpGet]
        public IActionResult MongoTest()
        {
            MongoDbContext db = new MongoDbContext();
            // Add a new customer and save it to the database
            db.MongoBase.Add(new MongoBase() { UserName = "DarkBolt" });
            db.SaveChanges();
            return Ok();
        }
    }
}
