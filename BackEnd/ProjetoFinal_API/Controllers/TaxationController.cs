using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal_API.Data.Repository.Interfaces;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxationController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IRepositoryTaxation _repositoryTaxation;

        public TaxationController(IRepository repository, IRepositoryTaxation repositoryTaxation)
        {
            this._repository = repository;
            this._repositoryTaxation = repositoryTaxation;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(
                    await _repositoryTaxation.GetAllAsync()
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the taxations, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("id={taxationId}")]
        public async Task<IActionResult> GetById(int taxationId)
        {
            try
            {
                return Ok(
                    await _repositoryTaxation.GetByIdAsync(taxationId)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the taxation by its id, an error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Taxation taxation)
        {
            try
            {
                _repository.Add(taxation);
                if (await this._repository.SaveChangesAsync())
                {
                    return Ok(taxation);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When posting the taxation, an error occurred: {ex.Message}");
            }
            return BadRequest("An error ocurred!");
        }

        [HttpPut("id={taxationId}")]
        public async Task<IActionResult> Put(int taxationId, Taxation taxation)
        {
            try
            {
                if (await _repositoryTaxation.GetByIdAsync(taxationId) == null)
                {
                    return NotFound();
                }
                _repository.Update(taxation);
                if (await this._repository.SaveChangesAsync())
                {
                    return Ok(taxation);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When updating the taxation, an error occurred: {ex.Message}");
            }
            return BadRequest("An error ocurred!");
        }

        [HttpDelete("id={taxationId}")]
        public async Task<IActionResult> Delete(int taxationId, Taxation taxation)
        {
            try
            {
                if (await _repositoryTaxation.GetByIdAsync(taxationId) == null)
                {
                    return NotFound();
                }
                _repository.Delete(taxation);
                if (await this._repository.SaveChangesAsync())
                {
                    return Ok(new {message="Taxation removed successfully!"});
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When removing the taxation, an error occurred: {ex.Message}");
            }
            return BadRequest("An error ocurred!");
        }
    }
}