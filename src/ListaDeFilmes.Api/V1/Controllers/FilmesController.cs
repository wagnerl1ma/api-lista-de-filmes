﻿using AutoMapper;
using ListaDeFilmes.Api.Controllers;
using ListaDeFilmes.Api.Extensions;
using ListaDeFilmes.Api.ViewModels;
using ListaDeFilmes.Business.Interfaces;
using ListaDeFilmes.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaDeFilmes.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/filmes")]
    //[Route("api/filmes")]
    public class FilmesController : MainController
    {
        private readonly IFilmeRepository _filmeRepository;
        private readonly IFilmeService _filmeService;
        private readonly IGeneroRepository _generoRepository;
        private readonly IMapper _mapper;

        public FilmesController(IFilmeRepository filmeRepository,
                                IFilmeService filmeService,
                                IGeneroRepository generoRepository,
                                IMapper mapper,
                                INotificador notificador,
                                IUser user) : base(notificador, user)
        {
            _filmeRepository = filmeRepository;
            _filmeService = filmeService;
            _generoRepository = generoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<FilmeViewModel>> ObterFilmesGeneros()
        {
            var filmesGeneros = _mapper.Map<IEnumerable<FilmeViewModel>>(await _filmeRepository.ObterFilmesGeneros());
            return filmesGeneros;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FilmeViewModel>> ObterPorId(Guid id)
        {
            var filme = _mapper.Map<FilmeViewModel>(await _filmeRepository.ObterPorId(id));

            if (filme == null)
                return NotFound(); //404

            return filme;
        }


        [ClaimsAuthorize("Filmes", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<FilmeViewModel>> Adicionar(FilmeViewModel filmeViewModel)
        {
            if (!ModelState.IsValid)
                //return BadRequest(); //exemplo teste
                return CustomResponse(ModelState);

            var filme = _mapper.Map<Filme>(filmeViewModel);
            await _filmeService.Adicionar(filme);

            return CustomResponse(filmeViewModel);
            //return Ok(filmeViewModel); //exemplo teste
        }

        [ClaimsAuthorize("Filmes", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<FilmeViewModel>> Atualizar(Guid id, FilmeViewModel filmeViewModel)
        {
            if (id != filmeViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(filmeViewModel);
                //return BadRequest(); //exemplo teste
            }

            var filmeAtualizacao = await ObterFilmePreenchido(id); //captura a informção do banco e faz a atualização

            filmeViewModel.Genero = filmeAtualizacao.Genero;
            filmeAtualizacao.GeneroId = filmeViewModel.GeneroId;
            filmeAtualizacao.Nome = filmeViewModel.Nome;
            filmeAtualizacao.Classificacao = filmeViewModel.Classificacao;
            filmeAtualizacao.Ano = filmeViewModel.Ano;
            filmeAtualizacao.Comentarios = filmeViewModel.Comentarios;
            filmeAtualizacao.Valor = filmeViewModel.Valor;
            filmeAtualizacao.Ativo = filmeViewModel.Ativo;

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);
            //return BadRequest(); //exemplo teste

            var filme = _mapper.Map<Filme>(filmeViewModel);
            await _filmeService.Atualizar(_mapper.Map<Filme>(filmeAtualizacao));

            return CustomResponse(filmeViewModel);
            //return Ok(filmeViewModel);  //exemplo teste

        }


        [ClaimsAuthorize("Filmes", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<FilmeViewModel>> Excluir(Guid id)
        {
            var filmeViewModel = await ObterFilmePreenchido(id);

            if (filmeViewModel == null)
                return NotFound();

            await _filmeService.Remover(id);

            return CustomResponse();
            //return CustomResponse(filmeViewModel); // se quiser mostrar o objeto que foi excluído, colocar o para o parametro "filmeViewModel" para retornar na resposta
            //return Ok(filmeViewModel);  //exemplo teste
        }

        private async Task<FilmeViewModel> ObterFilmePreenchido(Guid id)
        {
            var filme = _mapper.Map<FilmeViewModel>(await _filmeRepository.ObterFilmeGenero(id));
            filme.Generos = _mapper.Map<IEnumerable<GeneroViewModel>>(await _generoRepository.ObterTodos());

            return filme;
        }

        private async Task<FilmeViewModel> PopularGeneros(FilmeViewModel filme)
        {
            filme.Generos = _mapper.Map<IEnumerable<GeneroViewModel>>(await _generoRepository.ObterTodos());
            return filme;
        }
    }
}
