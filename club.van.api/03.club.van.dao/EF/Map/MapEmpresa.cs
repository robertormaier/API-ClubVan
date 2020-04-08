using club.van.api.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace club.van.api.dao.EF.Map
{
    public class MapEmpresa : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(x => x.Id).HasName("ID");
            builder.Property(x => x.Nome).HasColumnName("NOME").HasMaxLength(200);
            builder.Property(x => x.RazaoSocial).HasColumnName("RAZAO_SOCIAL").HasMaxLength(200);
            builder.Property(x => x.Cnpj).HasColumnName("CNPJ").HasMaxLength(200);
            builder.Property(x => x.Ativo).HasColumnName("ATIVO");
        }
    }
}
