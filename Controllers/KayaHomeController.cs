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
    }
}
