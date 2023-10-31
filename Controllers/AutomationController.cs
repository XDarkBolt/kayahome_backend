using Microsoft.AspNetCore.Mvc;

namespace kayahome_backend.Controllers
{
    public class AutomationController : BaseController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
