using Microsoft.EntityFrameworkCore;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<Company> Company { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<Taxation> Taxation { get; set; }
        public DbSet<RequestTaxation> RequestTaxation { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.Entity<AlunoDisciplina>()
            //     .HasKey(AD => new { AD.AlunoId, AD.DisciplinaId });

            builder.Entity<Company>()
                .HasData(new Company(1, "Test"));

            builder.Entity<Equipment>()
                .HasData(new Equipment(1, "Impressora", "HP", "Ink Sak", "BIASYRTCBO2U3809R2U38R"));

            builder.Entity<Person>()
                .HasData(new Person(1, 'E'/*'E'mployee|'C'lient*/, 'P'/*'P'hysical|'L'egal*/, "Thomas", "12345678901", "", 1, "casa do caraio", "1242535", "email@gmail.com"));

            builder.Entity<Request>()
                .HasData(new Request(1, 'O', 1, 1, "trocar a tinta", "tinta trocada - 2 pila"));
        }
    }
}