using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal_API.Data.Repository.Interfaces;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Data.Repository
{
    public class RepositoryTaxation : IRepositoryTaxation
    {
        private readonly DataContext _context;

        public RepositoryTaxation(DataContext context)
        {
            this._context = context;
        }

        public async Task<Taxation[]> GetAllAsync()
        {
            IQueryable<Taxation> query = _context.Taxation;
            query = query.AsNoTracking().OrderBy(t => t.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Taxation> GetByIdAsync(int taxationId)
        {
            IQueryable<Taxation> query = _context.Taxation;
            query = query.AsNoTracking().OrderBy(t => t.Id).Where(t => t.Id == taxationId);
            return await query.FirstOrDefaultAsync();
        }
    }
}