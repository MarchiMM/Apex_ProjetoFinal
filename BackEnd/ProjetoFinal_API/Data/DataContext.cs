using Microsoft.EntityFrameworkCore;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<Company> Company { get; set; }
        public DbSet<Equipament> Equipament { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<Taxation> Taxation { get; set; }
    }
}