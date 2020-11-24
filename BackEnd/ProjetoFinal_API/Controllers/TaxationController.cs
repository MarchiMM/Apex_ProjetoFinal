using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal_API.Context;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxationController : ControllerBase
    {
        private readonly ContextApp _context;

        public TaxationController(ContextApp context)
        {
            this._context = context;
        }

        [HttpGet]
        public IEnumerable<Taxation> Get()
        {
            return this._context.Taxation.ToList();
        }

        [HttpGet("id={id}")]
        public Taxation GetById(int id)
        {
            return this._context.Taxation.FirstOrDefault(t => t.Id == id);
        }

        [HttpGet("taxdescription={taxDescription}")]
        public Taxation GetByTaxDescription(string taxDescription)
        {
            return this._context.Taxation.FirstOrDefault(t => t.TaxDescription == taxDescription);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Taxation Taxation)
        {
            try
            {
                this._context.Taxation.Add(Taxation);
                this._context.SaveChanges();

                return Ok("Tax successfully registered.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Taxation taxation)
        {
            if (taxation.Id == id)
            {
                this._context.Entry(taxation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this._context.SaveChanges();

                return Ok("Registry updated.");
            }
            else
            {
                return BadRequest("The tax id is not equivalent.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var taxation = this._context.Taxation.FirstOrDefault(c => c.Id == id);
            if (taxation != null)
            {
                this._context.Taxation.Remove(taxation);
                this._context.SaveChanges();

                return Ok("Registry removed.");
            }
            else
            {
                return BadRequest("Tax not found.");
            }
        }
    }
}