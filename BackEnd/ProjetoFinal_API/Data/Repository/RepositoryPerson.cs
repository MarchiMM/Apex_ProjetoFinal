using System.Threading.Tasks;
using ProjetoFinal_API.Data.Repository.Interfaces;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Data.Repository
{
    public class RepositoryPerson : IRepositoryPerson
    {
        public Task<Person[]> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Person> GetByCnpjAsync(string cpf, bool includeCompany)
        {
            throw new System.NotImplementedException();
        }

        public Task<Person[]> GetByCompanyIdAsync(string companyId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Person[]> GetByCompanyNameAsync(string companyName)
        {
            throw new System.NotImplementedException();
        }

        public Task<Person> GetByCpfAsync(string cpf)
        {
            throw new System.NotImplementedException();
        }

        public Task<Person> GetByIdAsync(int companyId, bool includeCompany)
        {
            throw new System.NotImplementedException();
        }

        public Task<Person[]> GetByNameAsync(string name, bool includeCompany)
        {
            throw new System.NotImplementedException();
        }

        public Task<Person[]> GetByPersonTypeAsync(char personType)
        {
            throw new System.NotImplementedException();
        }

        public Task<Person[]> GetByTypeAsync(char type)
        {
            throw new System.NotImplementedException();
        }
    }
}