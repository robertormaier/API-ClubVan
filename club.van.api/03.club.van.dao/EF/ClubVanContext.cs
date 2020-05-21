using club.van.api.dao.EF.Map;
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
        public DbSet<ViagemDia> ViagemDias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=SQL5053.site4now.net;Initial Catalog=DB_A61B15_rmaier;User Id=DB_A61B15_rmaier_admin;Password=FQx!D@aD!6b!krz;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Usuario>().Ignore(x => x.Token);

            modelBuilder.ApplyConfiguration(new MapEmpresa());
            modelBuilder.ApplyConfiguration(new MapPerfil());
            modelBuilder.ApplyConfiguration(new MapRota());
            modelBuilder.ApplyConfiguration(new MapUsuario());
            modelBuilder.ApplyConfiguration(new MapVeiculo());
            modelBuilder.ApplyConfiguration(new MapViagemDias());

            base.OnModelCreating(modelBuilder);
        }
    }
}
