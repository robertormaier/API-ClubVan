using club.van.api.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace club.van.api.dao.EF.Map
{
    public class MapViagemDias : IEntityTypeConfiguration<ViagemDias>
    {
        public void Configure(EntityTypeBuilder<ViagemDias> builder)
        {
            builder.ToTable("VIAGEM_DIAS");
            builder.HasKey(x => x.Id).HasName("ID");
            builder.Property(x => x.NumeroSemana).HasColumnName("NUMERO_SEMANA");
            builder.Property(x => x.SegundaFeira).HasColumnName("SEGUNDA_FEIRA");
            builder.Property(x => x.TercaFeira).HasColumnName("TERCA_FEIRA");
            builder.Property(x => x.QuartaFeira).HasColumnName("QUARTA_FEIRA");
            builder.Property(x => x.QuintaFeira).HasColumnName("QUINTA_FEIRA");
            builder.Property(x => x.SextaFeira).HasColumnName("SEXTA_FEIRA");
            builder.Property(x => x.Sabado).HasColumnName("SABADO");
            builder.Property(x => x.Domingo).HasColumnName("DOMINGO");

            builder.HasOne(x => x.Usuario).WithMany().HasForeignKey("USUARIO_ID");
            builder.OwnsOne<Usuario>(x => x.Usuario, cb =>
            {
                cb.Property(x => x.Id).HasColumnName("USUARIO_ID");
            });

            builder.HasOne(x => x.Empresa).WithMany().HasForeignKey("EMPRESA_ID");
            builder.OwnsOne<Empresa>(x => x.Empresa, cb =>
            {
                cb.Property(x => x.Id).HasColumnName("EMPRESA_ID");
            });
        }
    }
}
