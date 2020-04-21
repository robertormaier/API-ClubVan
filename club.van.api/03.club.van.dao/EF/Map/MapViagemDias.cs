using club.van.api.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace club.van.api.dao.EF.Map
{
    public class MapViagemDias : IEntityTypeConfiguration<ViagemDia>
    {
        public void Configure(EntityTypeBuilder<ViagemDia> builder)
        {
            builder.ToTable("VIAGEM_DIA");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NumeroSemana).HasColumnName("NUMERO_SEMANA");
            builder.Property(x => x.SegundaFeira).HasColumnName("SEGUNDA_FEIRA");
            builder.Property(x => x.TercaFeira).HasColumnName("TERCA_FEIRA");
            builder.Property(x => x.QuartaFeira).HasColumnName("QUARTA_FEIRA");
            builder.Property(x => x.QuintaFeira).HasColumnName("QUINTA_FEIRA");
            builder.Property(x => x.SextaFeira).HasColumnName("SEXTA_FEIRA");
            builder.Property(x => x.Sabado).HasColumnName("SABADO");
            builder.Property(x => x.Domingo).HasColumnName("DOMINGO");

            builder.HasOne(x => x.Usuario).WithMany().HasForeignKey("USUARIO_ID");
            builder.HasOne(x => x.Rota).WithMany().HasForeignKey("ROTA_ID");
        }
    }
}
