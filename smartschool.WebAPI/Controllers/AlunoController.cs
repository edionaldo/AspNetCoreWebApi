using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using smartschool.WebAPI.Models;

namespace smartschool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>() {
            new Aluno() {
                Id = 1,
                Nome = "Marcos",
                Sobrenome = "Almeida",
                Telefone = "12345678"
            },
            new Aluno() {
                Id = 2,
                Nome = "Marta",
                Sobrenome = "Kent",
                Telefone = "987654321"
            },
            new Aluno() {
                Id = 3,
                Nome = "Laura",
                Sobrenome = "Maria",
                Telefone = "65464755"
            }
        };
        public AlunoController() {}

        // api/aluno
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }
        
        // api/aluno/byId?id=1
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null) return BadRequest("O Aluno não foi encontrado!");

            return Ok(aluno);
        }

        // http://localhost:5000/api/aluno/byName?nome=Marta&sobrenome=Kent
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a => 
                a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome)
            );

            if (aluno == null) return BadRequest("O Aluno não foi encontrado!");

            return Ok(aluno);
        }

        // http://localhost:5000/api/aluno
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        // http://localhost:5000/api/aluno/byName?nome=Marta&sobrenome=Kent
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        // http://localhost:5000/api/aluno/byName?nome=Marta&sobrenome=Kent
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        // http://localhost:5000/api/aluno/byName?nome=Marta&sobrenome=Kent
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, Aluno aluno)
        {
            return Ok();
        }        
    }
}