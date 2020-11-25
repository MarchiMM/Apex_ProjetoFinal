using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal_API.Context;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class RequestController : ControllerBase
    {
        private readonly ContextApp _context;

        public RequestController(ContextApp context)
        {
            this._context = context;
        }

        [HttpGet]
        public IEnumerable<Request> Get()
        {
            return this._context.Request.ToList();
        }

        [HttpGet("id={id}")]
        public Request GetById(int id)
        {
            return this._context.Request.FirstOrDefault(r => r.Id == id);
        }

        [HttpGet("status={status}")]
        public IEnumerable<Request> GetByStatus(char status)
        {
            return this._context.Request.Where(r => r.Status == status).ToList();
        }

        [HttpGet("personname={personname}")]
        public IEnumerable<Request> GetByStatus(char status)
        {
            return this._context.Request.Where(r => r.Person.Name.Equals(personname)).ToList();
        }

        [HttpPost]
        public IActionResult Post([FromBody]Request request)
        {
            try
            {
                this._context.Request.Add(request);
                this._context.SaveChanges();

                return Ok("Request successfully registered.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Company request)
        {
            if (request.Id == id)
            {
                this._context.Entry(request).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this._context.SaveChanges();

                return Ok("Registry updated.");
            }
            else
            {
                return BadRequest("The Request id is not equivalent.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var request = this._context.Request.FirstOrDefault(c => c.Id == id);
            if (request != null)
            {
                this._context.Request.Remove(request);
                this._context.SaveChanges();

                return Ok("Registry removed.");
            }
            else
            {
                return BadRequest("Request not found.");
            }
        }
    }
}