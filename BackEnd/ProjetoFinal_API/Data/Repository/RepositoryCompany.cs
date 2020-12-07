using System.Linq;
using System.Threading.Tasks;
using ProjetoFinal_API.Data.Repository.Interfaces;
using ProjetoFinal_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoFinal_API.Data.Repository
{
    public class RepositoryCompany : IRepositoryCompany
    {
        private readonly DataContext _context;

        public RepositoryCompany(DataContext context)
        {
            this._context = context;
        }

        public async Task<Company[]> GetAllAsync()
        {
            IQueryable<Company> query = _context.Company;
            query = query.AsNoTracking().OrderBy(c => c.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Company> GetByIdAsync(int companyId, bool includePersons)
        {
            IQueryable<Company> query = _context.Company;
            if (includePersons)
            {
                query = query.Include(c => c.Persons);
            }
            query = query.AsNoTracking().OrderBy(c => c.Id).Where(c => c.Id == companyId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Company> GetByCompanyName(string companyName, bool includePersons)
        {
            IQueryable<Company> query = _context.Company;
            if (includePersons)
            {
                query = query.Include(c => c.Persons);
            }
            query = query.AsNoTracking().OrderBy(c => c.Id).Where(c => c.Name == companyName);
            return await query.FirstOrDefaultAsync();
        }
    }
}