using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal_API.Data.Repository.Interfaces;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
        public class EquipmentController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IRepositoryEquipment _repositoryEquipment;

        public EquipmentController(IRepository repository, IRepositoryEquipment repositoryEquipment)
        {
            this._repository = repository;
            this._repositoryEquipment = repositoryEquipment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(
                    await _repositoryEquipment.GetAllAsync()
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the equipments, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("id={equipmentId}")]
        public async Task<IActionResult> GetById(int equipmentId)
        {
            try
            {
                return Ok(
                    await _repositoryEquipment.GetByIdAsync(equipmentId, includeRequests: true)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the equipment by its id, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("type={equipmentType}")]
        public async Task<IActionResult> GetByType(string equipmentType)
        {
            try
            {
                return Ok(
                    await _repositoryEquipment.GetByTypeAsync(equipmentType)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the equipments by their type, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("brand={equipmentBrand}")]
        public async Task<IActionResult> GetByBrand(string equipmentBrand)
        {
            try
            {
                return Ok(
                    await _repositoryEquipment.GetByBrandAsync(equipmentBrand)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the equipments by their brand, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("model={equipmentModel}")]
        public async Task<IActionResult> GetByModel(string equipmentModel)
        {
            try
            {
                return Ok(
                    await _repositoryEquipment.GetByModelAsync(equipmentModel)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the equipments by their model, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("serialnumber={equipmentSerialNumber}")]
        public async Task<IActionResult> GetBySerialNumber(string equipmentSerialNumber)
        {
            try
            {
                return Ok(
                    await _repositoryEquipment.GetBySerialNumberAsync(equipmentSerialNumber, includeRequests: true)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the equipment by its serialnumber, an error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Equipment equipment)
        {
            try
            {
                _repository.Add(equipment);
                if (await this._repository.SaveChangesAsync())
                {
                    return Ok(equipment);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When posting the equipment, an error occurred: {ex.Message}");
            }
            return BadRequest("An error ocurred!");
        }

        [HttpPut("id={equipmentId}")]
        public async Task<IActionResult> Put(int equipmentId, Equipment equipment)
        {
            try
            {
                if (await _repositoryEquipment.GetByIdAsync(equipmentId, includeRequests: false) == null)
                {
                    return NotFound();
                }
                _repository.Update(equipment);
                if (await this._repository.SaveChangesAsync())
                {
                    return Ok(equipment);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When updating the equipment, an error occurred: {ex.Message}");
            }
            return BadRequest("An error ocurred!");
        }

        [HttpDelete("id={equipmentId}")]
        public async Task<IActionResult> Delete(int equipmentId)
        {
            try
            {
                var equipment = await _repositoryEquipment.GetByIdAsync(equipmentId, includeRequests: false);
                if (equipment == null)
                {
                    return NotFound();
                }
                _repository.Delete(equipment);
                if (await this._repository.SaveChangesAsync())
                {
                    return Ok(new {message="Equipment removed successfully!"});
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When removing the equipment, an error occurred: {ex.Message}");
            }
            return BadRequest("An error ocurred!");
        }
    }
}