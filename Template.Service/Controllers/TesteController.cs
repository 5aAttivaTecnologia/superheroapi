using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Template.Cadastro.Api.ViewModels;

namespace Template.Cadastro.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Teste")]
    public class TesteController : Controller
    {
        //public void Post([FromBody]TesteEvenlopeViewModel teste)
        //{

        //}

        [HttpPost]
        public void Post([FromBody] TesteViewModel testeViewModel, TesteDoTesteViewModel testeDoTesteViewModel)
        {

        }

        [HttpGet]
        public string Get()
        {
            return "ahdufhashdfaushdfua";
        }
    }
}