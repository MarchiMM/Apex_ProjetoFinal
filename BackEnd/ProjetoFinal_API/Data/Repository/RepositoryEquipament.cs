using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal_API.Data.Repository.Interfaces;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Data.Repository
{
    public class RepositoryEquipament : IRepositoryEquipament
    {
        private readonly DataContext _context;

        public RepositoryEquipament(DataContext context)
        {
            this._context = context;
        }

        public async Task<Equipament[]> GetAllAsync()
        {
            IQueryable<Equipament> query = _context.Equipament;
            query = query.AsNoTracking().OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Equipament[]> GetByBrandAsync(string brand)
        {
            IQueryable<Equipament> query = _context.Equipament;
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Brand == brand);
            return await query.ToArrayAsync();
        }

        public async Task<Equipament> GetByIdAsync(int equipamentId)
        {
            IQueryable<Equipament> query = _context.Equipament;
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == equipamentId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Equipament[]> GetByModelAsync(string model)
        {
            IQueryable<Equipament> query = _context.Equipament;
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Model == model);
            return await query.ToArrayAsync();
        }

        public async Task<Equipament> GetBySerialNumberAsync(string serialNumber)
        {
            IQueryable<Equipament> query = _context.Equipament;
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.SerialNumber == serialNumber);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Equipament[]> GetByTypeAsync(string type)
        {
            IQueryable<Equipament> query = _context.Equipament;
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Type == type);
            return await query.ToArrayAsync();
        }
    }
}