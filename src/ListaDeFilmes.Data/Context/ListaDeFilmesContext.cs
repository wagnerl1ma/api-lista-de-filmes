using ListaDeFilmes.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListaDeFilmes.Data.Context
{
    public class ListaDeFilmesContext : DbContext
    {
        public ListaDeFilmesContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Ator> Atores { get; set; }
        public DbSet<Diretor> Diretores { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<FilmeAtor> FilmesAtores { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Produtora> Produtoras { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Apenas para STRING: caso esquecer de passar o tamanho da string nas mappings/configurations, o código abaixo irá criar o campo no banco de dados com o tamanho "varchar(100)"
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            //registra todas as mappings/configurations de uma vez só, ao inves de escrever uma por uma
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ListaDeFilmesContext).Assembly);

            //Impedindo a exclusão por cascata
            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
