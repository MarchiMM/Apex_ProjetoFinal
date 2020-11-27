using System.Threading.Tasks;
using ProjetoFinal_API.Data.Repository.Interfaces;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Data.Repository
{
    public class RepositoryRequest : IRepositoryRequest
    {
        public Task<Request[]> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Request[]> GetByEquipamentBrandAsync(string equipamentBrand)
        {
            throw new System.NotImplementedException();
        }

        public Task<Request> GetByEquipamentIdAsync(int equipamentId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Request[]> GetByEquipamentModelAsync(string equipamentModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<Request> GetByEquipamentSerialNumberlAsync(string equipamentSerialNumber)
        {
            throw new System.NotImplementedException();
        }

        public Task<Request[]> GetByEquipamentTypeAsync(string equipamentType)
        {
            throw new System.NotImplementedException();
        }

        public Task<Request> GetByIdAsync(int companyId, bool includeCompany)
        {
            throw new System.NotImplementedException();
        }

        public Task<Request> GetByPersonIdAsync(int personId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Request> GetByPersonNameAsync(string personName)
        {
            throw new System.NotImplementedException();
        }

        public Task<Request[]> GetByStatusAsync(char status)
        {
            throw new System.NotImplementedException();
        }
    }
}