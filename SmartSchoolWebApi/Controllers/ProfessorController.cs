using Microsoft.AspNetCore.Mvc;

namespace SmartSchoolWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {

        [HttpGet]
        public IActionResult get()
        {
            return Ok("Felipe");
        }
    }
}