using ListaDeFilmes.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ListaDeFilmes.Business.Interfaces
{
    public interface IGeneroRepository : IRepository<Genero>
    {
        Task<List<Genero>> GetGenerosAsync();
    }
}
