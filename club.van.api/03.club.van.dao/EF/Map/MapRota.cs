using club.van.api.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace club.van.api.dao.EF.Map
{
    public class MapRota : IEntityTypeConfiguration<Rota>
    {
        public void Configure(EntityTypeBuilder<Rota> builder)
        {
            builder.ToTable("ROTA");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnName("NOME").HasMaxLength(50);

            builder.HasOne(x => x.Veiculo).WithMany().HasForeignKey("VEICULO_ID");
            builder.HasOne(x => x.Empresa).WithMany().HasForeignKey("EMPRESA_ID");       }
    }
}
