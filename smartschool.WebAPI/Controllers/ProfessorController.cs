using System.Linq;
using Microsoft.AspNetCore.Mvc;
using smartschool.WebAPI.Data;
using smartschool.WebAPI.Models;

namespace smartschool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly DataContext _context;

        public ProfessorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);
            if (professor == null) return BadRequest("Professor não encontrado!");

            return Ok(professor);
        }
        
        [HttpGet("byName")]
        public IActionResult GetByName(string nome)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Nome == nome);
            if (professor == null) return BadRequest("Professor não encontrado!");

            return Ok(prof);
        }
        
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _context.Professores.FirstOrDefault(p => p.Id == id);
            if (prof == null) return BadRequest("Professor não encontrado!");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }       

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _context.Professores.FirstOrDefault(p => p.Id == id);
            if (prof == null) return BadRequest("Professor não encontrado!");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);
            if (professor == null) return BadRequest("Professor não encontrado!");

            _context.Remove(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        
    }
}