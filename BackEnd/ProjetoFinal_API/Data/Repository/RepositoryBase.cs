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
    }
}