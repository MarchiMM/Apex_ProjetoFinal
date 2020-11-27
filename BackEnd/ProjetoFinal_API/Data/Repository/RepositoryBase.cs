using System.Threading.Tasks;
using ProjetoFinal_API.Data.Repository.Interfaces;

namespace ProjetoFinal_API.Data.Repository
{
    public class RepositoryBase : IRepository
    {
        private readonly DataContext _context;

        public RepositoryBase(DataContext context)
        {
            this._context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            this._context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            this._context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            this._context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}