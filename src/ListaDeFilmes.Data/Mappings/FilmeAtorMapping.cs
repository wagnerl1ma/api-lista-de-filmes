using ListaDeFilmes.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListaDeFilmes.Data.Mappings
{
    public class FilmeAtorMapping : IEntityTypeConfiguration<FilmeAtor>
    {
        public void Configure(EntityTypeBuilder<FilmeAtor> builder)
        {
            builder.ToTable("Tb_FilmesAtores");

            builder.HasKey(fa => new { fa.FilmeId, fa.AtorId }); //definindo chave composta para FilmeAtor

            //modelBuilder.Entity<FilmeAtor>(hb => { hb.HasKey(x => new { x.FilmeId, x.AtorId }); });  //defininco chave composta para FilmeAtor

            builder.Property(fa => fa.FilmeId).HasColumnName("Id_Filme").IsRequired();

            builder.Property(fa => fa.AtorId).HasColumnName("Id_Ator").IsRequired();
        }
    }
}
