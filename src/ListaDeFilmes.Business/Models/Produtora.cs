using System.Collections.Generic;

namespace ListaDeFilmes.Business.Models
{
    public class Produtora : Entity
    {
        public string Nome { get; set; }

        public List<Filme> Filmes { get; set; }

        //public Produtora()
        //{

        //}

        //public Produtora(string nome)
        //{
        //    Nome = nome;
        //}

        //public Produtora(Guid id, string nome)
        //{
        //    Id = id;
        //    Nome = nome;
        //}
    }
}