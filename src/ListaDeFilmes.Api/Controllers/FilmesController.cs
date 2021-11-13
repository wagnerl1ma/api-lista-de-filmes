using AutoMapper;
using ListaDeFilmes.Api.ViewModels;
using ListaDeFilmes.Business.Interfaces;
using ListaDeFilmes.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaDeFilmes.Api.Controllers
{
    [Route("api/filmes")]
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
                                INotificador notificador) : base(notificador)
        {
            _filmeRepository = filmeRepository;
            _filmeService = filmeService;
            _generoRepository = generoRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<FilmeViewModel>> ObterFilmesGeneros()
        {
            var filmesGeneros = _mapper.Map<IEnumerable<FilmeViewModel>>(await _filmeRepository.ObterFilmesGeneros());
            return filmesGeneros;
        }
    }
}
