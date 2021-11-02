using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ListaDeFilmes.Api.ViewModels
{
    public class DiretorViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public ICollection<FilmeViewModel> Filmes { get; set; }
    }
}
