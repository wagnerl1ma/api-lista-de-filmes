using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListaDeFilmes.Api.ViewModels
{
    public class ProdutoraViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public List<FilmeViewModel> Filmes { get; set; }
    }
}
