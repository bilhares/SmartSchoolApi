using Microsoft.AspNetCore.Mvc;
using SmartSchoolWebApi.Data;
using System;
using System.Threading.Tasks;

namespace SmartSchoolWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllAlunosAsync(false);
                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }      
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByAlunoId(int id)
        {
            try
            {
                var result = await _repo.GetAlunoAsyncById(id, false);
                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }



    }
}