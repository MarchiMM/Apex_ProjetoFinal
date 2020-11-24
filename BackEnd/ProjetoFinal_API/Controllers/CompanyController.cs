using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal_API.Context;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ContextApp _context;

        public CompanyController(ContextApp context)
        {
            this._context = context;
        }

        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return this._context.Company.ToList();
        }

        [HttpGet("id={id}")]
        public Company GetById(int id)
        {
            return this._context.Company.FirstOrDefault(c => c.Id == id);
        }

        [HttpGet("name={name}")]
        public Company GetByName(string name)
        {
            return this._context.Company.FirstOrDefault(c => c.Name == name);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Company company)
        {
            try
            {
                this._context.Company.Add(company);
                this._context.SaveChanges();

                return Ok("Company successfully registered.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Company company)
        {
            if (company.Id == id)
            {
                this._context.Entry(company).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this._context.SaveChanges();

                return Ok("Registry updated.");
            }
            else
            {
                return BadRequest("The company id is not equivalent.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var company = this._context.Company.FirstOrDefault(c => c.Id == id);
            if (company != null)
            {
                this._context.Company.Remove(company);
                this._context.SaveChanges();

                return Ok("Registry removed.");
            }
            else
            {
                return BadRequest("Company not found.");
            }
        }
    }
}