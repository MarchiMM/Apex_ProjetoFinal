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

        public async Task<Request[]> GetByEquipmentBrandAsync(string equipmentBrand)
        {
            IQueryable<Request> query = _context.Request;
            query = query.AsNoTracking().OrderBy(r => r.Id).Where(r => r.Equipment.Brand == equipmentBrand);
            return await query.ToArrayAsync();
        }

        public async Task<Request[]> GetByEquipmentIdAsync(int equipmentId)
        {
            IQueryable<Request> query = _context.Request;
            query = query.AsNoTracking().OrderBy(r => r.Id).Where(r => r.Equipment.Id == equipmentId);
            return await query.ToArrayAsync();
        }

        public async Task<Request[]> GetByEquipmentModelAsync(string equipmentModel)
        {
            IQueryable<Request> query = _context.Request;
            query = query.AsNoTracking().OrderBy(r => r.Id).Where(r => r.Equipment.Model == equipmentModel);
            return await query.ToArrayAsync();
        }

        public async Task<Request[]> GetByEquipmentSerialNumberlAsync(string equipmentSerialNumber)
        {
            IQueryable<Request> query = _context.Request;
            query = query.AsNoTracking().OrderBy(r => r.Id).Where(r => r.Equipment.SerialNumber == equipmentSerialNumber);
            return await query.ToArrayAsync();
        }

        public async Task<Request[]> GetByEquipmentTypeAsync(string equipmentType)
        {
            IQueryable<Request> query = _context.Request;
            query = query.AsNoTracking().OrderBy(r => r.Id).Where(r => r.Equipment.Type == equipmentType);
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
            query = query.AsNoTracking().OrderBy(r => r.Id).Where(r => r.Person.Id == personId);
            return await query.ToArrayAsync();
        }

        public async Task<Request[]> GetByPersonNameAsync(string personName)
        {
            IQueryable<Request> query = _context.Request;
            query = query.AsNoTracking().OrderBy(r => r.Id).Where(r => r.Person.Name == personName);
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