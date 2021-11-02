using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ListaDeFilmes.Api.ViewModels
{
    public class GeneroViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "É necessário colocar o {0}")] //obrigatorio
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O tamanho do {0} deve ser entre {2} e {1} caracteres!")]   //  0 = nome, 2 = tamanho minimo, 1 = tamanho máximo
        public string Nome { get; set; }

        public ICollection<FilmeViewModel> Filmes { get; set; } = new List<FilmeViewModel>();   //= O new List<Filme> garante que a lista seja instanciada  //Relacionamento: um genero tem em vários filmes
    }
}
