using ListaDeFilmes.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeFilmes.Business.Interfaces
{
    public interface IFilmeService : IDisposable
    {
        Task Adicionar(Filme fornecedor);
        Task Atualizar(Filme fornecedor);
        Task Remover(Guid id);
        //Task<Filme> ObterFilmePreenchido(Guid id);
    }
}
