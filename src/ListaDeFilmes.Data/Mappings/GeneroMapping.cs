using ListaDeFilmes.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListaDeFilmes.Data.Mappings
{
    public class GeneroMapping : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.ToTable("Tb_Generos");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id).HasColumnName("Id_Genero").IsRequired();

            builder.Property(g => g.Nome).HasColumnName("Nome_Genero").HasColumnType("varchar(100)").IsRequired();


            //um Genero tem muitos filmes
            builder.HasMany(g => g.Filmes);
        }
    }
}
