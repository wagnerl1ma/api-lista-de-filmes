using System.Collections.Generic;

namespace ListaDeFilmes.Business.Models
{
    public class Ator : Entity
    {
        public string Nome { get; set; }

        // Um Ator pode ter vários Filmes (Relacionamneto muitos para muitos)
        public ICollection<FilmeAtor> FilmesAtores { get; set; } //= new List<FilmeAtor>();     

        //public Ator()
        //{

        //}

        //public Ator(string nome)
        //{
        //    Nome = nome;
        //}

        //public Ator(Guid id, string nome)
        //{
        //    Id = id;
        //    Nome = nome;
        //}
    }
}
