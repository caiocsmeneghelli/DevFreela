using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}