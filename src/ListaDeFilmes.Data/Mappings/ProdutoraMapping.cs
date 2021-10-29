using ListaDeFilmes.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListaDeFilmes.Data.Mappings
{
    public class ProdutoraMapping : IEntityTypeConfiguration<Produtora>
    {
        public void Configure(EntityTypeBuilder<Produtora> builder)
        {
            builder.ToTable("Tb_Produtoras");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id_Produtora").IsRequired();

            builder.Property(p => p.Nome).HasColumnName("Nome_Produtora").HasColumnType("varchar(100)").IsRequired();


            //Uma produtora tem muitos filmes
            builder.HasMany(p => p.Filmes);
        }
    }
}
