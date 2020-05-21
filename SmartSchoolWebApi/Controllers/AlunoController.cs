using Microsoft.AspNetCore.Mvc;
using SmartSchoolWebApi.Data;
using SmartSchoolWebApi.Models;
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
                var result = await _repo.GetAllAlunosAsync(true);
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
                var result = await _repo.GetAlunoAsyncById(id, true);
                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("byDisciplinaId/{id}")]
        public async Task<IActionResult> GetByAlunoByDisciplina(int id)
        {
            try
            {
                var result = await _repo.GetAlunosAsyncByDisciplinaId(id, false);
                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }



        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Aluno model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Aluno model)
        {
            try
            {
                var aluno = await _repo.GetAlunoAsyncById(id, false);

                if (aluno == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return BadRequest();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var aluno = await _repo.GetAlunoAsyncById(id, false);

                if (aluno == null) return NotFound();

                _repo.Delete(aluno);

                if (await _repo.SaveChangesAsync())
                {
                    return NoContent();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return BadRequest();
        }
    }
}