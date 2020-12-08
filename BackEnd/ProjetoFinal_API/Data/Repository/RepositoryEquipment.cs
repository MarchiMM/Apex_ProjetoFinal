using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal_API.Data.Repository.Interfaces;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Data.Repository
{
    public class RepositoryEquipment : IRepositoryEquipment
    {
        private readonly DataContext _context;

        public RepositoryEquipment(DataContext context)
        {
            this._context = context;
        }

        public async Task<Equipment[]> GetAllAsync()
        {
            IQueryable<Equipment> query = _context.Equipment;
            query = query.AsNoTracking().OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Equipment[]> GetByBrandAsync(string brand)
        {
            IQueryable<Equipment> query = _context.Equipment;
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Brand == brand);
            return await query.ToArrayAsync();
        }

        public async Task<Equipment> GetByIdAsync(int equipmentId)
        {
            IQueryable<Equipment> query = _context.Equipment;
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == equipmentId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Equipment[]> GetByModelAsync(string model)
        {
            IQueryable<Equipment> query = _context.Equipment;
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Model == model);
            return await query.ToArrayAsync();
        }

        public async Task<Equipment> GetBySerialNumberAsync(string serialNumber)
        {
            IQueryable<Equipment> query = _context.Equipment;
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.SerialNumber == serialNumber);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Equipment[]> GetByTypeAsync(string type)
        {
            IQueryable<Equipment> query = _context.Equipment;
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Type == type);
            return await query.ToArrayAsync();
        }
    }
}