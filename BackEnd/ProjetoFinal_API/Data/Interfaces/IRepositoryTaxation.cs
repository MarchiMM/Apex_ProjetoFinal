using System.Threading.Tasks;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Data.Repository.Interfaces
{
    public interface IRepositoryTaxation
    {
        Task<Taxation[]> GetAllAsync();
        Task<Taxation> GetByIdAsync(int taxationId);
    }
}