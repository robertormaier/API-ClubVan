using club.van.api.data;
using Microsoft.EntityFrameworkCore;

namespace club.van.api.dao.EF
{
    public class ClubVanContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Rota> Rotas { get; set; }
        public DbSet<ViagemDias> ViagemDias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-4DEOMFG;Initial Catalog=DB_CLUBVAN;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
