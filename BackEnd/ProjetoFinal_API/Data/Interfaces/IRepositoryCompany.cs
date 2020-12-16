using System.Threading.Tasks;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Data.Repository.Interfaces
{
    public interface IRepositoryCompany
    {
        Task<Company[]> GetAllAsync();
        Task<Company> GetByIdAsync(int companyId, bool includePeople);
        Task<Company> GetByCompanyName(string companyName, bool includePeople);
    }
}