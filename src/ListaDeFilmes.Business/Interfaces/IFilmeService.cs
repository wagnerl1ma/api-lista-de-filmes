using ListaDeFilmes.Business.Models;
using System;
using System.Threading.Tasks;

namespace ListaDeFilmes.Business.Interfaces
{
    public interface IFilmeService : IDisposable
    {
        Task<bool> Adicionar(Filme fornecedor);
        Task<bool> Atualizar(Filme fornecedor);
        Task Remover(Guid id);
        //Task<Filme> ObterFilmePreenchido(Guid id);
    }
}
