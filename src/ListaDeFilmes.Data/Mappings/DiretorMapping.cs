using ListaDeFilmes.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListaDeFilmes.Data.Mappings
{
    public class DiretorMapping : IEntityTypeConfiguration<Diretor>
    {
        public void Configure(EntityTypeBuilder<Diretor> builder)
        {
            builder.ToTable("Tb_Diretores");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id).HasColumnName("Id_Diretor").IsRequired();

            builder.Property(d => d.Nome).HasColumnName("Nome_Diretor").HasColumnType("varchar(100)").IsRequired();

            //Um diretor pode ter muitos filmes
            builder.HasMany(d => d.Filmes);

        }
    }
}
