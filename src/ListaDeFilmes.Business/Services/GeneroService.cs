using ListaDeFilmes.Business.Interfaces;
using ListaDeFilmes.Business.Models;
using ListaDeFilmes.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace ListaDeFilmes.Business.Services
{
    public class GeneroService : BaseService, IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;
        //private readonly IUser _user;  caso necessitar capturar a informação do usuário(identity) logado, injetar o IUser no construtor.

        public GeneroService(IGeneroRepository generoRepository, INotificador notificador) : base(notificador)
        {
            _generoRepository = generoRepository;
        }
        public async Task<bool> Adicionar(Genero genero)
        {
            //se a Validação não for valida, retorna a notificação e nao faz a adição
            if (!ExecutarValidacao(new GeneroValidation(), genero)) 
                return false;

            await _generoRepository.Adicionar(genero);
            return true;
        }

        public async Task<bool> Atualizar(Genero genero)
        {
            //se a Validação não for valida, retorna e nao faz a atualização
            if (!ExecutarValidacao(new GeneroValidation(), genero)) 
                return false;

            await _generoRepository.Atualizar(genero);
            return true;
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
