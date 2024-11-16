using System.Collections.Generic;

namespace ListaDeFilmes.Business.Models
{
    public class Diretor : Entity
    {
        public string Nome { get; set; }

        public ICollection<Filme> Filmes { get; set; }

        //public Diretor()
        //{

        //}

        //public Diretor(string nome)
        //{
        //    Nome = nome;
        //}

        //public Diretor(Guid id, string nome)
        //{
        //    Id = id;
        //    Nome = nome;
        //}
    }
}