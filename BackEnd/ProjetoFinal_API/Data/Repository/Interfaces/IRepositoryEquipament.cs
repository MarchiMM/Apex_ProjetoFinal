using System.Threading.Tasks;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Data.Repository.Interfaces
{
    public interface IRepositoryEquipament
    {
        Task<Equipament[]> GetAllAsync();
        Task<Equipament> GetByIdAsync(int equipamentId);
        Task<Equipament[]> GetByTypeAsync(string type);
        Task<Equipament[]> GetByBrandAsync(string brand);
        Task<Equipament[]> GetByModelAsync(string model);
        Task<Equipament> GetBySerialNumberAsync(string serialNumber);
    }
}