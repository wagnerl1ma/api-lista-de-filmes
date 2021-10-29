using System;
using System.Collections.Generic;

namespace ListaDeFilmes.Business.Models
{
    public class Genero : Entity
    {
        public string Nome { get; set; }

        public ICollection<Filme> Filmes { get; set; } = new List<Filme>();   //= O new List<Filme> garante que a lista seja instanciada  //Relacionamento: um genero tem em vários filmes


        //public Genero()
        //{

        //}

        //public Genero(string nome)
        //{
        //    Nome = nome;
        //}

        //public Genero(Guid id, string nome)
        //{
        //    Id = id;
        //    Nome = nome;
        //}

        //public void AddFilme(Filme filme)
        //{
        //    Filmes.Add(filme);
        //}
    }
}