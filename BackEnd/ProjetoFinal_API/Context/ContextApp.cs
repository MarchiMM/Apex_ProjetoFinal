using Microsoft.EntityFrameworkCore;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Context
{
    public class ContextApp : DbContext
    {
        public ContextApp(DbContextOptions<ContextApp> options) : base(options) {}
        public DbSet<Client> Client { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Equipament> Equipament { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<Taxation> Taxation { get; set; }

    }
}