using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal_API.Data.Repository.Interfaces;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IRepositoryCompany _repositoryCompany;

        public CompanyController(IRepository repository, IRepositoryCompany repositoryCompany)
        {
            this._repository = repository;
            this._repositoryCompany = repositoryCompany;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(
                    await _repositoryCompany.GetAllAsync()
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the companies, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("id={companyId}")]
        public async Task<IActionResult> GetById(int companyId)
        {
            try
            {
                return Ok(
                    await _repositoryCompany.GetByIdAsync(companyId, includePeople: true)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the company by its id, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("name={companyName}")]
        public async Task<IActionResult> GetByName(string companyName)
        {
            try
            {
                return Ok(
                    await _repositoryCompany.GetByCompanyName(companyName, includePeople: true)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the company by its name, an error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Company company)
        {
            try
            {
                _repository.Add(company);
                if (await this._repository.SaveChangesAsync())
                {
                    return Ok(company);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When posting the company, an error occurred: {ex.Message}");
            }
            return BadRequest("An error ocurred!");
        }

        [HttpPut("id={companyId}")]
        public async Task<IActionResult> Put(int companyId, Company company)
        {
            try
            {
                if (await _repositoryCompany.GetByIdAsync(companyId, includePeople: false) == null)
                {
                    return NotFound();
                }
                _repository.Update(company);
                if (await this._repository.SaveChangesAsync())
                {
                    return Ok(company);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When updating the company, an error occurred: {ex.Message}");
            }
            return BadRequest("An error ocurred!");
        }

        [HttpDelete("id={companyId}")]
        public async Task<IActionResult> Delete(int companyId)
        {
            try
            {
                var company = await _repositoryCompany.GetByIdAsync(companyId, includePeople: false);
                if (company == null)
                {
                    return NotFound();
                }
                _repository.Delete(company);
                if (await this._repository.SaveChangesAsync())
                {
                    return Ok(new {message="Company removed successfully!"});
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When removing the company, an error occurred: {ex.Message}");
            }
            return BadRequest("An error ocurred!");
        }
    }
}