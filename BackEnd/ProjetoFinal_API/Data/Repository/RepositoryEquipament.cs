using System.Threading.Tasks;
using ProjetoFinal_API.Data.Repository.Interfaces;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Data.Repository
{
    public class RepositoryEquipament : IRepositoryEquipament
    {
        public Task<Equipament[]> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Equipament[]> GetByBrandAsync(string brand)
        {
            throw new System.NotImplementedException();
        }

        public Task<Equipament> GetByIdAsync(int companyId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Equipament[]> GetByModelAsync(string model)
        {
            throw new System.NotImplementedException();
        }

        public Task<Equipament> GetBySerialNumberAsync(string serialNumber)
        {
            throw new System.NotImplementedException();
        }

        public Task<Equipament[]> GetByTypeAsync(string type)
        {
            throw new System.NotImplementedException();
        }
    }
}