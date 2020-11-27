using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal_API.Data;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return this._context.Person.ToList();
        }

        [HttpGet("id={id}")]
        public Person GetById(int id)
        {
            return this._context.Person.FirstOrDefault(p => p.Id == id);
        }

        [HttpGet("name={name}")]
        public Person GetByName(string name)
        {
            return this._context.Person.FirstOrDefault(p => p.Name == name);
        }

        [HttpGet("type={type}")]
        public IEnumerable<Person> GetByType(char type)
        {
            return this._context.Person.Where(p => p.Type == type).ToList();
        }

        [HttpGet("persontype={personType}")]
        public IEnumerable<Person> GetByPersonType(char personType)
        {
            return this._context.Person.Where(p => p.Type == personType).ToList();
        }

        [HttpGet("cpf={cpf}")]
        public Person GetByCpf(string cpf)
        {
            return this._context.Person.FirstOrDefault(p => p.Cpf == cpf);
        }

        [HttpGet("cnpj={cnpj}")]
        public Person GetByCnpj(string cnpj)
        {
            return this._context.Person.FirstOrDefault(p => p.Cnpj == cnpj);
        }

        [HttpGet("companyname={companyId}")]
        public IEnumerable<Person> GetByCompanyId(int companyId)
        {
            return this._context.Person.Where(p => p.CompanyId == companyId).ToList();
        }

        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            try
            {
                this._context.Person.Add(person);
                this._context.SaveChanges();

                return Ok("Person successfully registered.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Person person)
        {
            if (person.Id == id)
            {
                this._context.Entry(person).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this._context.SaveChanges();

                return Ok("Registry updated.");
            }
            else
            {
                return BadRequest("The Person id is not equivalent.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var person = this._context.Person.FirstOrDefault(c => c.Id == id);
            if (person != null)
            {
                this._context.Person.Remove(person);
                this._context.SaveChanges();

                return Ok("Registry removed.");
            }
            else
            {
                return BadRequest("Person not found.");
            }
        }
    }
}