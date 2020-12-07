using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal_API.Data.Repository.Interfaces;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Data.Repository
{
    public class RepositoryRequest : IRepositoryRequest
    {
        private readonly DataContext _context;

        public RepositoryRequest(DataContext context)
        {
            this._context = context;
        }

        public async Task<Request[]> GetAllAsync()
        {
            IQueryable<Request> query = _context.Request;
            query = query.AsNoTracking().OrderBy(r => r.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Request[]> GetByEquipamentBrandAsync(string equipamentBrand)
        {
            IQueryable<Request> query = _context.Request;
            query = query.AsNoTracking().OrderBy(r => r.Id).Where(r => r.Equipaments.Any(e => e.Brand == equipamentBrand));
            return await query.ToArrayAsync();
        }

        public async Task<Request[]> GetByEquipamentIdAsync(int equipamentId)
        {
            IQueryable<Request> query = _context.Request;
            query = query.AsNoTracking().OrderBy(r => r.Id).Where(r => r.Equipaments.Any(e => e.Id == equipamentId));
            return await query.ToArrayAsync();
        }

        public async Task<Request[]> GetByEquipamentModelAsync(string equipamentModel)
        {
            IQueryable<Request> query = _context.Request;
            query = query.AsNoTracking().OrderBy(r => r.Id).Where(r => r.Equipaments.Any(e => e.Model == equipamentModel));
            return await query.ToArrayAsync();
        }

        public async Task<Request[]> GetByEquipamentSerialNumberlAsync(string equipamentSerialNumber)
        {
            IQueryable<Request> query = _context.Request;
            query = query.AsNoTracking().OrderBy(r => r.Id).Where(r => r.Equipaments.Any(e => e.SerialNumber == equipamentSerialNumber));
            return await query.ToArrayAsync();
        }

        public async Task<Request[]> GetByEquipamentTypeAsync(string equipamentType)
        {
            IQueryable<Request> query = _context.Request;
            query = query.AsNoTracking().OrderBy(r => r.Id).Where(r => r.Equipaments.Any(e => e.Type == equipamentType));
            return await query.ToArrayAsync();
        }

        public async Task<Request> GetByIdAsync(int requestId, bool includePerson)
        {
            IQueryable<Request> query = _context.Request;
            if (includePerson)
            {
                query = query.Include(r => r.Person);
            }
            query = query.AsNoTracking().OrderBy(r => r.Id).Where(r => r.Id == requestId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Request[]> GetByPersonIdAsync(int personId)
        {
            IQueryable<Request> query = _context.Request;
            query = query.AsNoTracking().OrderBy(r => r.Id).Where(r => r.People.Any(p => p.Id == personId));
            return await query.ToArrayAsync();
        }

        public async Task<Request[]> GetByPersonNameAsync(string personName)
        {
            IQueryable<Request> query = _context.Request;
            query = query.AsNoTracking().OrderBy(r => r.Id).Where(r => r.People.Any(p => p.Name == personName));
            return await query.ToArrayAsync();
        }

        public async Task<Request[]> GetByStatusAsync(char status)
        {
            IQueryable<Request> query = _context.Request;
            query = query.AsNoTracking().OrderBy(r => r.Id).Where(r => r.Status == status);
            return await query.ToArrayAsync();
        }
    }
}