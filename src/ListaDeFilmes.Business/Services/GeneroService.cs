using ListaDeFilmes.Business.Interfaces;
using ListaDeFilmes.Business.Models;
using ListaDeFilmes.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeFilmes.Business.Services
{
    public class GeneroService : BaseService, IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroService(IGeneroRepository generoRepository, INotificador notificador) : base(notificador)
        {
            _generoRepository = generoRepository;
        }
        public async Task Adicionar(Genero genero)
        {
            //se a Validação não for valida, retorna a notificação e nao faz a adição
            if (!ExecutarValidacao(new GeneroValidation(), genero)) return;

            await _generoRepository.Adicionar(genero);
        }

        public async Task Atualizar(Genero genero)
        {
            //se a Validação não for valida, retorna e nao faz a atualização
            if (!ExecutarValidacao(new GeneroValidation(), genero)) return;

            await _generoRepository.Atualizar(genero);
        }

        public async Task Remover(Guid id)
        {
            await _generoRepository.Remover(id);
        }

        public void Dispose()
        {
            //? = Se ele existir faça o Dispose, se nao exister não faça
            _generoRepository?.Dispose();
        }
    }
}
