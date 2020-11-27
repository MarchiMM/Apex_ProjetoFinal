using System.Threading.Tasks;
using ProjetoFinal_API.Data.Repository.Interfaces;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Data.Repository
{
    public class RepositoryTaxation : IRepositoryTaxation
    {
        public Task<Taxation[]> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Taxation> GetByIdAsync(int taxationId)
        {
            throw new System.NotImplementedException();
        }
    }
}