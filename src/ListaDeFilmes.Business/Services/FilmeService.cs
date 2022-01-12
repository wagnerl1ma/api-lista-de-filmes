using ListaDeFilmes.Business.Interfaces;
using ListaDeFilmes.Business.Models;
using ListaDeFilmes.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeFilmes.Business.Services
{
    public class FilmeService : BaseService, IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;
        private readonly IGeneroRepository _generoRepository;
        //private readonly IUser _user;  caso necessitar capturar a informação do usuário(identity) logado, injetar o IUser no construtor.

        public FilmeService(IFilmeRepository filmeRepository, IGeneroRepository generoRepository, INotificador notificador) : base(notificador)
        {
            _filmeRepository = filmeRepository;
            _generoRepository = generoRepository;
        }

        public async Task<bool> Adicionar(Filme filme)
        {
            //se a Validação não for valida, retorna a notificação e nao faz a adição
            if (!ExecutarValidacao(new FilmeValidation(), filme)) 
                return false;

            await _filmeRepository.Adicionar(filme);
            return true;
        }

        public async Task<bool> Atualizar(Filme filme)
        {
            if (!ExecutarValidacao(new FilmeValidation(), filme)
                || !ExecutarValidacao(new GeneroValidation(), filme.Genero)) 
                return false;

            filme.Genero = await _generoRepository.ObterPorId(filme.GeneroId);

            await _filmeRepository.Atualizar(filme);
            return true;
        }

        public async Task Remover(Guid id)
        {
            await _filmeRepository.Remover(id);
        }

        public async Task<Filme> ObterFilmePreenchido(Guid id)
        {
            var filme = await _filmeRepository.ObterFilmeGenero(id);
            filme.Genero = await _generoRepository.ObterPorId(filme.GeneroId);

            return filme;
        }

        public void Dispose()
        {
            //? = Se ele existir faça o Dispose, se nao exister não faça
            _filmeRepository?.Dispose();
            _generoRepository?.Dispose();
        }
    }
}
