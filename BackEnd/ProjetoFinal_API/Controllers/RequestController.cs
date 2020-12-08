using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal_API.Data.Repository.Interfaces;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class RequestController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IRepositoryRequest _repositoryRequest;

        public RequestController(IRepository repository, IRepositoryRequest repositoryRequest)
        {
            this._repository = repository;
            this._repositoryRequest = repositoryRequest;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(
                    await _repositoryRequest.GetAllAsync()
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the requests, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("id={requestId}")]
        public async Task<IActionResult> GetById(int requestId)
        {
            try
            {
                return Ok(
                    await _repositoryRequest.GetByIdAsync(requestId, includePerson: true)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the request by its id, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("status={requestStatus}")]
        public async Task<IActionResult> GetByStatus(char requestStatus)
        {
            try
            {
                return Ok(
                    await _repositoryRequest.GetByStatusAsync(requestStatus)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the requests by their status, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("personid={personId}")]
        public async Task<IActionResult> GetByPersonId(int personId)
        {
            try
            {
                return Ok(
                    await _repositoryRequest.GetByPersonIdAsync(personId)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the requests by their person_id, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("personname={personName}")]
        public async Task<IActionResult> GetByPersonName(string personName)
        {
            try
            {
                return Ok(
                    await _repositoryRequest.GetByPersonNameAsync(personName)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the requests by their person_name, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("equipmentid={equipmentId}")]
        public async Task<IActionResult> GetByEquimentId(int equipmentid)
        {
            try
            {
                return Ok(
                    await _repositoryRequest.GetByEquipmentIdAsync(equipmentid)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the request by their equipment_id, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("equipmenttype={equipmentType}")]
        public async Task<IActionResult> GetByEquipmentType(string equipmentType)
        {
            try
            {
                return Ok(
                    await _repositoryRequest.GetByEquipmentTypeAsync(equipmentType)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the requests by their equipment_type, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("equipmentbrand={equipmentBrand}")]
        public async Task<IActionResult> GetByEquipmentBrand(string equipmentBrand)
        {
            try
            {
                return Ok(
                    await _repositoryRequest.GetByEquipmentBrandAsync(equipmentBrand)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the requests by their equipment_brand, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("equipmentmodel={equipmentModel}")]
        public async Task<IActionResult> GetByEquipmentModel(string equipmentModel)
        {
            try
            {
                return Ok(
                    await _repositoryRequest.GetByEquipmentModelAsync(equipmentModel)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the requests by their equipment_model, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("equipmentserialnumber={equipmentSerialNumber}")]
        public async Task<IActionResult> GetByEquipmentSerialNumber(string equipmentSerialNumber)
        {
            try
            {
                return Ok(
                    await _repositoryRequest.GetByEquipmentSerialNumberlAsync(equipmentSerialNumber)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"When obtaining the requests by their equipment_serialnumber, an error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Request request)
        {
            try
            {
                _repository.Add(request);
                if (await this._repository.SaveChangesAsync())
                {
                    return Ok(request);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When posting the request, an error occurred: {ex.Message}");
            }
            return BadRequest("An error ocurred!");
        }

        [HttpPut("id={requestId}")]
        public async Task<IActionResult> Put(int requestId, Request request)
        {
            try
            {
                if (await _repositoryRequest.GetByIdAsync(requestId, includePerson: false) == null)
                {
                    return NotFound();
                }
                _repository.Update(request);
                if (await this._repository.SaveChangesAsync())
                {
                    return Ok(request);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When updating the request, an error occurred: {ex.Message}");
            }
            return BadRequest("An error ocurred!");
        }

        [HttpDelete("id={requestId}")]
        public async Task<IActionResult> Delete(int requestId, Request request)
        {
            try
            {
                if (await _repositoryRequest.GetByIdAsync(requestId, includePerson: false) == null)
                {
                    return NotFound();
                }
                _repository.Delete(request);
                if (await this._repository.SaveChangesAsync())
                {
                    return Ok(new {message="Request removed successfully!"});
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When removing the request, an error occurred: {ex.Message}");
            }
            return BadRequest("An error ocurred!");
        }
    }
}