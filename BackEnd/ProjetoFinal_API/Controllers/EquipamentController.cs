using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal_API.Data;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
        public class EquipamentController : ControllerBase
    {
        private readonly DataContext _context;

        public EquipamentController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IEnumerable<Equipament> Get()
        {
            return this._context.Equipament.ToList();
        }

        [HttpGet("id={id}")]
        public Equipament GetById(int id)
        {
            return this._context.Equipament.FirstOrDefault(e => e.Id == id);
        }

        [HttpGet("type={type}")]
        public IEnumerable<Equipament> GetByType(string type)
        {
            return this._context.Equipament.Where(e => e.Type == type).ToList();
        }

        [HttpGet("brand={brand}")]
        public IEnumerable<Equipament> GetByBrand(string brand)
        {
            return this._context.Equipament.Where(e => e.Brand == brand).ToList();
        }

        [HttpGet("model={model}")]
        public IEnumerable<Equipament> GetByModel(string model)
        {
            return this._context.Equipament.Where(e => e.Model == model).ToList();
        }

        [HttpGet("type={type}")]
        public IEnumerable<Equipament> GetBySerialNumber(string serialNumber)
        {
            return this._context.Equipament.Where(e => e.SerialNumber == serialNumber).ToList();
        }

        [HttpPost]
        public IActionResult Post([FromBody]Equipament equipament)
        {
            try
            {
                this._context.Equipament.Add(equipament);
                this._context.SaveChanges();

                return Ok("Equipament successfully registered.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Equipament equipament)
        {
            if (equipament.Id == id)
            {
                this._context.Entry(equipament).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this._context.SaveChanges();

                return Ok("Registry updated.");
            }
            else
            {
                return BadRequest("The equipament id is not equivalent.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var equipament = this._context.Equipament.FirstOrDefault(c => c.Id == id);
            if (equipament != null)
            {
                this._context.Equipament.Remove(equipament);
                this._context.SaveChanges();

                return Ok("Registry removed.");
            }
            else
            {
                return BadRequest("Equipament not found.");
            }
        }
    }
}