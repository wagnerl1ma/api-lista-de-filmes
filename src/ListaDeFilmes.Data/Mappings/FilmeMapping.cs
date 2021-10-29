using ListaDeFilmes.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListaDeFilmes.Data.Mappings
{
    public class FilmeMapping : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("Tb_Filmes");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id).HasColumnName("Id_Filme").IsRequired();

            builder.Property(f => f.Nome).HasColumnName("Nome_Filmes").HasColumnType("varchar(100)").IsRequired();

            builder.Property(f => f.DataCadastro).HasColumnName("Data_Cadastro").IsRequired(false);

            builder.Property(f => f.Classificacao).HasColumnName("Classificacao_Filme").HasColumnType("varchar(5)").IsRequired();

            builder.Property(f => f.Ano).HasColumnName("Ano_Filme").HasColumnType("int").IsRequired(false);

            builder.Property(f => f.Comentarios).HasColumnName("Comentarios_Filme").HasColumnType("varchar(300)").IsRequired(false);

            builder.Property(p => p.Imagem).HasColumnType("varchar(200)").IsRequired();

            builder.Property(p => p.Valor).HasColumnType("decimal(18,2)").IsRequired();

            builder.Property(p => p.Ativo).HasColumnType("bit").IsRequired();


            builder.Property(f => f.GeneroId).HasColumnName("Id_Genero").IsRequired();

            builder.Property(f => f.DiretorId).HasColumnName("Id_Diretor").IsRequired(false);  //TODO: RETIRAR A OPÇÃO DE ACEITAR NULO QUANDO TERMINAR O CRUD E A SERVICE

            builder.Property(f => f.ProdutoraId).HasColumnName("Id_Produtora").IsRequired(false);  //TODO: RETIRAR A OPÇÃO DE ACEITAR NULO QUANDO TERMINAR O CRUD E A SERVICE


            //builder.HasMany(x => x.FilmesAtores); // Um Filme pode ter muitos Atores
            builder.HasOne(f => f.Genero).WithMany(g => g.Filmes).HasForeignKey(f => f.GeneroId);  // Um Filme só pode ter um Genero e um Genero pode ter muitos filmes
            builder.HasOne(f => f.Diretor).WithMany(d => d.Filmes).HasForeignKey(f => f.DiretorId);  // Um Filme só pode ter um Diretor e um Diretor pode ter vários filmes
            builder.HasOne(f => f.Produtora).WithMany(p => p.Filmes).HasForeignKey(f => f.ProdutoraId); // Um Filme só pode ter uma Produtora e uma Produtora pode ter vários filmes

        }
    }
}
