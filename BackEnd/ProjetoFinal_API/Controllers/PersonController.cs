using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal_API.Data.Repository.Interfaces;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IRepositoryPerson _repositoryPerson;

        public PersonController(IRepository repository, IRepositoryPerson repositoryPerson)
        {
            this._repository = repository;
            this._repositoryPerson = repositoryPerson;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(
                    await _repositoryPerson.GetAllAsync()
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the people, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("id={personId}")]
        public async Task<IActionResult> GetById(int personId)
        {
            try
            {
                return Ok(
                    await _repositoryPerson.GetByIdAsync(personId, includeCompany: true, includeRequests: true)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the person by its id, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("type={type}")]
        public async Task<IActionResult> GetByType(char type)
        {
            try
            {
                return Ok(
                    await _repositoryPerson.GetByTypeAsync(type)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the people by their type, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("persontype={personType}")]
        public async Task<IActionResult> GetByPersonType(char personType)
        {
            try
            {
                return Ok(
                    await _repositoryPerson.GetByPersonTypeAsync(personType)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the people by their person_type, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("name={personName}")]
        public async Task<IActionResult> GetByName(string personName)
        {
            try
            {
                return Ok(
                    await _repositoryPerson.GetByNameAsync(personName, includeCompany: true, includeRequests: true)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the person by its name, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("cpf={personCpf}")]
        public async Task<IActionResult> GetByCpf(string personCpf)
        {
            try
            {
                return Ok(
                    await _repositoryPerson.GetByCpfAsync(personCpf)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the person by its cpf, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("cnpj={personCnpj}")]
        public async Task<IActionResult> GetByCnpj(string personCnpj)
        {
            try
            {
                return Ok(
                    await _repositoryPerson.GetByCnpjAsync(personCnpj, includeCompany: true, includeRequests: true)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the person by its cnpj, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("companyid={companyId}")]
        public async Task<IActionResult> GetByCompanyId(int companyId)
        {
            try
            {
                return Ok(
                    await _repositoryPerson.GetByCompanyIdAsync(companyId)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the people by their company_id, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("companyname={companyName}")]
        public async Task<IActionResult> GetByCompanyName(string companyName)
        {
            try
            {
                return Ok(
                    await _repositoryPerson.GetByCompanyNameAsync(companyName)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the people by their company_name, an error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Person person)
        {
            try
            {
                _repository.Add(person);
                if (await this._repository.SaveChangesAsync())
                {
                    return Ok(person);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When posting the person, an error occurred: {ex.Message}");
            }
            return BadRequest("An error ocurred!");
        }

        [HttpPut("id={personId}")]
        public async Task<IActionResult> Put(int personId, Person person)
        {
            try
            {
                if (await _repositoryPerson.GetByIdAsync(personId, includeCompany: false, includeRequests: false) == null)
                {
                    return NotFound();
                }
                _repository.Update(person);
                if (await this._repository.SaveChangesAsync())
                {
                    return Ok(person);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When updating the person, an error occurred: {ex.Message}");
            }
            return BadRequest("An error ocurred!");
        }

        [HttpDelete("id={personId}")]
        public async Task<IActionResult> Delete(int personId)
        {
            try
            {
                var person = await _repositoryPerson.GetByIdAsync(personId, includeCompany: false, includeRequests: false);
                if (person == null)
                {
                    return NotFound();
                }
                _repository.Delete(person);
                if (await this._repository.SaveChangesAsync())
                {
                    return Ok(new {message="Person removed successfully!"});
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When removing the person, an error occurred: {ex.Message}");
            }
            return BadRequest("An error ocurred!");
        }
    }
}