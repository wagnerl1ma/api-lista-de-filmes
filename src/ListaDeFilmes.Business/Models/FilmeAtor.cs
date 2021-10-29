using System;

namespace ListaDeFilmes.Business.Models
{
    public class FilmeAtor : Entity            // inserir Chave Composta com 2 Ids
    {
        public Filme Filme { get; set; }
        public Guid FilmeId { get; set; }

        public Ator Ator { get; set; }
        public Guid AtorId { get; set; }

        //public FilmeAtor()
        //{

        //}

        //public FilmeAtor(Filme filme, Ator ator)
        //{
        //    Filme = filme;
        //    Ator = ator;
        //}

        //public FilmeAtor(Guid filmeId, Filme filme, Guid atorId, Ator ator)
        //{
        //    FilmeId = filmeId;
        //    Filme = filme;
        //    AtorId = atorId;
        //    Ator = ator;
        //}
    }
}