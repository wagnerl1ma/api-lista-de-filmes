using ListaDeFilmes.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeFilmes.Business.Interfaces
{
    public interface IGeneroService : IDisposable
    {
        Task Adicionar(Genero fornecedor);
        Task Atualizar(Genero fornecedor);
        Task Remover(Guid id);

        //Task AtualizarGenero(Genero genero);
    }
}
