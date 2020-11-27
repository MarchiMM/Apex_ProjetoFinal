using System.Threading.Tasks;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Data.Repository.Interfaces
{
    public interface IRepositoryRequest
    {
        Task<Request[]> GetAllAsync();
        Task<Request> GetByIdAsync(int companyId, bool includeCompany);
        Task<Request[]> GetByStatusAsync(char status);
        Task<Request> GetByPersonIdAsync(int personId);
        Task<Request> GetByPersonNameAsync(string personName);
        Task<Request> GetByEquipamentIdAsync(int equipamentId);
        Task<Request[]> GetByEquipamentTypeAsync(string equipamentType);
        Task<Request[]> GetByEquipamentBrandAsync(string equipamentBrand);
        Task<Request[]> GetByEquipamentModelAsync(string equipamentModel);
        Task<Request> GetByEquipamentSerialNumberlAsync(string equipamentSerialNumber);
    }
}