using ListaDeFilmes.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ListaDeFilmes.Data.Mappings
{
    public class AtorMapping : IEntityTypeConfiguration<Ator>
    {
        public void Configure(EntityTypeBuilder<Ator> builder)
        {
            builder.ToTable("Tb_Atores");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("Id_Ator").IsRequired();

            builder.Property(a => a.Nome).HasColumnName("Nome_Ator").HasColumnType("varchar(100)").IsRequired();

            //um ator pode ter muitos filmes
            builder.HasMany(a => a.FilmesAtores);
        }
    }
}
