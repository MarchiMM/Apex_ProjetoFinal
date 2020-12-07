using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal_API.Data.Repository.Interfaces;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Data.Repository
{
    public class RepositoryPerson : IRepositoryPerson
    {
        private readonly DataContext _context;

        public RepositoryPerson(DataContext context)
        {
            this._context = context;
        }

        public async Task<Person[]> GetAllAsync()
        {
            IQueryable<Person> query = _context.Person;
            query = query.AsNoTracking().OrderBy(p => p.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Person> GetByCnpjAsync(string cnpj, bool includeCompany)
        {
            IQueryable<Person> query = _context.Person;
            if (includeCompany)
            {
                query = query.Include(p => p.Company);
            }
            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Cnpj == cnpj);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Person[]> GetByCompanyIdAsync(int companyId)
        {
            IQueryable<Person> query = _context.Person;
            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.CompanyId == companyId);
            return await query.ToArrayAsync();
        }

        public async Task<Person[]> GetByCompanyNameAsync(string companyName)
        {
            IQueryable<Person> query = _context.Person;
            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Companies.Any(c => c.Name == companyName));
            return await query.ToArrayAsync();
        }

        public async Task<Person> GetByCpfAsync(string cpf)
        {
            IQueryable<Person> query = _context.Person;
            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Cpf == cpf);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Person> GetByIdAsync(int personId, bool includeCompany)
        {
            IQueryable<Person> query = _context.Person;
            if (includeCompany)
            {
                query = query.Include(p => p.Company);
            }
            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Id == personId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Person[]> GetByNameAsync(string name, bool includeCompany)
        {
            IQueryable<Person> query = _context.Person;
            if (includeCompany)
            {
                query = query.Include(p => p.Company);
            }
            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Name == name);
            return await query.ToArrayAsync();
        }

        public async Task<Person[]> GetByPersonTypeAsync(char personType)
        {
            IQueryable<Person> query = _context.Person;
            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.PersonType == personType);
            return await query.ToArrayAsync();
        }

        public async Task<Person[]> GetByTypeAsync(char type)
        {
            IQueryable<Person> query = _context.Person;
            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Type == type);
            return await query.ToArrayAsync();
        }
    }
}