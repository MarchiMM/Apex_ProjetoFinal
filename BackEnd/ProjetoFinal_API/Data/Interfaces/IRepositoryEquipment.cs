using System.Threading.Tasks;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Data.Repository.Interfaces
{
    public interface IRepositoryEquipment
    {
        Task<Equipment[]> GetAllAsync();
        Task<Equipment> GetByIdAsync(int equipmentId, bool includeRequests);
        Task<Equipment[]> GetByTypeAsync(string type);
        Task<Equipment[]> GetByBrandAsync(string brand);
        Task<Equipment[]> GetByModelAsync(string model);
        Task<Equipment> GetBySerialNumberAsync(string serialNumber, bool includeRequests);
    }
}