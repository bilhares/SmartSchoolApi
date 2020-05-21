using Microsoft.AspNetCore.Mvc;
using SmartSchoolWebApi.Data;
using SmartSchoolWebApi.Models;
using System;
using System.Threading.Tasks;

namespace SmartSchoolWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {

        private IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> get()
        {
            try
            {

                var professores = await _repo.GetAllProfessoresAsync(true);
                return Ok(professores);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getById(int id)
        {
            try
            {

                var professores = await _repo.GetProfessorAsyncById(id,true);
                return Ok(professores);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }       
        
        [HttpGet("byAlunoId/{id}")]
        public async Task<IActionResult> getByAlunoId(int id)
        {
            try
            {

                var professores = await _repo.GetProfessoresAsyncByAlunoId(id,true);
                return Ok(professores);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }   
        [HttpPost]
        public async Task<IActionResult> post(Professor model)
        {
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync())
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
        public async Task<IActionResult> put(int id, Professor model)
        {
            try
            {
                var prof = await _repo.GetProfessorAsyncById(id, false);
                if (prof == null) return NotFound("Professor nao encontrado");

                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
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
        public async Task<IActionResult> delete(int id)
        {
            try
            {
                var prof = await _repo.GetProfessorAsyncById(id, false);
                if (prof == null) return NotFound("Professor nao encontrado");

                _repo.Delete(prof);

                if(await _repo.SaveChangesAsync())
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