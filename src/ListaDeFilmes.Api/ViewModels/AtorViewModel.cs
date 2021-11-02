using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ListaDeFilmes.Api.ViewModels
{
    public class AtorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Nome { get; set; }

        // Um Ator pode ter vários Filmes (Relacionamneto muitos para muitos)
        public ICollection<FilmeAtorViewModel> FilmesAtores { get; set; } //= new List<FilmeAtor>();     

    }
}
