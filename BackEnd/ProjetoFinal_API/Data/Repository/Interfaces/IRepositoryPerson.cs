using System.Threading.Tasks;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Data.Repository.Interfaces
{
    public interface IRepositoryPerson
    {
        Task<Person[]> GetAllAsync();
        Task<Person> GetByIdAsync(int companyId, bool includeCompany, bool includeRequests);
        Task<Person[]> GetByTypeAsync(char type);
        Task<Person[]> GetByPersonTypeAsync(char personType);
        Task<Person[]> GetByNameAsync(string name, bool includeCompany, bool includeRequests);
        Task<Person> GetByCpfAsync(string cpf);
        Task<Person> GetByCnpjAsync(string cpf, bool includeCompany, bool includeRequests);
        Task<Person[]> GetByCompanyIdAsync(int companyId);
        Task<Person[]> GetByCompanyNameAsync(string companyName);
        // tentar utilizar funções do Repository Company
        /*
            public IEnumerable<Person> GetByCompanyNameAsync(string name)
            {
                return Company.GetByName(name);
            }
        */
    }
}