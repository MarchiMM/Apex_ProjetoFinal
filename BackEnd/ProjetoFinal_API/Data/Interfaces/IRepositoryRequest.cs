using System.Threading.Tasks;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Data.Repository.Interfaces
{
    public interface IRepositoryRequest
    {
        Task<Request[]> GetAllAsync();
        Task<Request> GetByIdAsync(int requestId, bool includePerson);
        Task<Request[]> GetByStatusAsync(char status);
        Task<Request[]> GetByPersonIdAsync(int personId);
        Task<Request[]> GetByPersonNameAsync(string personName);
        Task<Request[]> GetByEquipmentIdAsync(int equipmentId);
        Task<Request[]> GetByEquipmentTypeAsync(string equipmentType);
        Task<Request[]> GetByEquipmentBrandAsync(string equipmentBrand);
        Task<Request[]> GetByEquipmentModelAsync(string equipmentModel);
        Task<Request[]> GetByEquipmentSerialNumberlAsync(string equipmentSerialNumber);
    }
}