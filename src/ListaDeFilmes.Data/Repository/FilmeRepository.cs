using ListaDeFilmes.Business.Interfaces;
using ListaDeFilmes.Business.Models;
using ListaDeFilmes.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeFilmes.Data.Repository
{
    public class FilmeRepository : Repository<Filme>, IFilmeRepository
    {
        public FilmeRepository(ListaDeFilmesContext context) : base(context) { }

        public async Task<Filme> ObterFilmeGenero(Guid id)
        {
            return await Db.Filmes.AsNoTracking().Include(g => g.Genero).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<List<Filme>> ObterFilmesGeneros()
        {
            return await Db.Filmes.AsNoTracking().Include(x => x.Genero).ToListAsync(); //instanciando o Genero junto com a lista de filmes
        }

        public async Task<List<Filme>> PesquisaNomeFilme(string nomeFilme)
        {
            var query = Db.Filmes.AsNoTracking()
               .Where(x => x.Nome.Contains(nomeFilme))
               .Include(x => x.Genero) //join
               .OrderBy(x => x.Nome);

            return await query.ToListAsync();
        }
    }
}
