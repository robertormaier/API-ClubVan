using club.van.api.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace club.van.api.dao.EF.Map
{
    public class MapUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnName("NOME").HasMaxLength(200);
            builder.Property(x => x.Cpf).HasColumnName("CPF").HasMaxLength(200);
            builder.Property(x => x.Email).HasColumnName("EMAIL").HasMaxLength(200);
            builder.Property(x => x.Senha).HasColumnName("SENHA").HasMaxLength(200);
            builder.Property(x => x.Ativo).HasColumnName("ATIVO");
            builder.Property(x => x.Bairro).HasColumnName("BAIRRO");
            builder.Property(x => x.Rua).HasColumnName("RUA");
            builder.Property(x => x.Cidade).HasColumnName("CIDADE");
            builder.Property(x => x.Uf).HasColumnName("UF");

            builder.HasOne(x => x.Perfil).WithMany().HasForeignKey("PERFIL_ID");
            builder.HasOne(x => x.Empresa).WithMany().HasForeignKey("EMPRESA_ID");
            builder.HasOne(x => x.Rota).WithMany().HasForeignKey("ROTA_ID");
        }
    }
}
