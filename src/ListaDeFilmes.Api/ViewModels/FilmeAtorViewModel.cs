using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListaDeFilmes.Api.ViewModels
{
    public class FilmeAtorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public FilmeViewModel Filme { get; set; }
        public Guid FilmeId { get; set; }

        public AtorViewModel Ator { get; set; }
        public Guid AtorId { get; set; }
    }
}
