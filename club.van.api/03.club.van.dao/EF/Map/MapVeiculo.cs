using club.van.api.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace club.van.api.dao.EF.Map
{
    public class MapVeiculo : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("VEICULO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Placa).HasColumnName("PLACA").HasMaxLength(50);
            builder.Property(x => x.Modelo).HasColumnName("MODELO").HasMaxLength(50);
            builder.Property(x => x.Descricao).HasColumnName("DESCRICAO").HasMaxLength(50);
        }
    }
}
