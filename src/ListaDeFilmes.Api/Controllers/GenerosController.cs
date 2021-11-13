using ListaDeFilmes.Business.Interfaces;
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
        
        public GenerosController(INotificador notificador) : base(notificador)
        {

        }
    }
}
