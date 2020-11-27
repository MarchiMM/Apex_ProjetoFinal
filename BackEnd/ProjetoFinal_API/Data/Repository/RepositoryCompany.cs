using System.Threading.Tasks;
using ProjetoFinal_API.Data.Repository.Interfaces;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Data.Repository
{
    public class RepositoryCompany : IRepositoryCompany
    {
        public Task<Company[]> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Company> GetByCompanyName(string companyName, bool includePersons)
        {
            throw new System.NotImplementedException();
        }

        public Task<Company> GetByIdAsync(int companyId, bool includePersons)
        {
            throw new System.NotImplementedException();
        }
    }
}