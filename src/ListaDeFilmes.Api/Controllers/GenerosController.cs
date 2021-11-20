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

        //[ClaimsAuthorize("Generos", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<GeneroViewModel>> Adicionar(GeneroViewModel generoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            //return CustomResponse(ModelState);

            var genero = _mapper.Map<Genero>(generoViewModel);
            await _generoService.Adicionar(genero);

            //return CustomResponse(filmeViewModel);
            return Ok(genero);
        }

        //[ClaimsAuthorize("Generos", "Editar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<GeneroViewModel>> Atualizar(Guid id, GeneroViewModel generoViewModel)
        {
            if (id != generoViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                //return CustomResponse(filmeViewModel);
                return BadRequest(); //exemplo teste
            }

            if (!ModelState.IsValid)
                //return CustomResponse(ModelState);
                return BadRequest(); //exemplo teste

            var genero = _mapper.Map<Genero>(generoViewModel);
            await _generoService.Atualizar(genero);

            //return CustomResponse(filmeViewModel);
            return Ok(genero);  //exemplo teste
        }

        //[ClaimsAuthorize("Generos", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<GeneroViewModel>> Excluir(Guid id)
        {
            var generoViewModel = _mapper.Map<GeneroViewModel>(await _generoRepository.ObterPorId(id));

            if (generoViewModel == null)
                return NotFound();

            await _generoService.Remover(id);

            //return CustomResponse(filmeViewModel);
            return Ok(generoViewModel);  //exemplo teste
        }


    }
}
