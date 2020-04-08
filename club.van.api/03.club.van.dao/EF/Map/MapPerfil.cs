using club.van.api.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace club.van.api.dao.EF.Map
{
    public class MapPerfil : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("PERFIL");
            builder.HasKey(x => x.Id).HasName("ID");
            builder.Property(x => x.Nome).HasColumnName("NOME").HasMaxLength(200);
        }
    }
}
