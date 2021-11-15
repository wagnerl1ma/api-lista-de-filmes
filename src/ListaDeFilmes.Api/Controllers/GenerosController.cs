using AutoMapper;
using ListaDeFilmes.Api.ViewModels;
using ListaDeFilmes.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaDeFilmes.Api.Controllers
{
    [Route("api/generos")]
    public class GenerosController : MainController
    {

        private readonly IGeneroRepository _generoRepository;
        private readonly IGeneroService _generoService;
        private readonly IMapper _mapper;

        public GenerosController(IGeneroRepository generoRepository,
                                 IGeneroService generoService,
                                 IMapper mapper,
                                 INotificador notificador) : base(notificador)
        {
            _generoRepository = generoRepository;
            _generoService = generoService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<GeneroViewModel>> ObterGeneros()
        {
            var generos = _mapper.Map<IEnumerable<GeneroViewModel>>(await _generoRepository.ObterTodos());
            return generos;
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FilmeViewModel>> ObterPorId(Guid id)
        {
            var genero = _mapper.Map<FilmeViewModel>(await _generoRepository.ObterPorId(id));

            if (genero == null)
                return NotFound(); //404

            return genero;
        }


    }
}
