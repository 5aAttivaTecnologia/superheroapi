using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Template.Cadastro.Api.ViewModels;
using Template.Cadastro.Domain.Entities;
using Template.Domain.Interfaces.Repositories;
using Template.Domain.Interfaces.Services;
using AutoMapper;
using Template.Core.Domain.Interfaces;
using Template.Core.Domain.Events;
using Template.Framework;
using Template.Cadastro.Domain.DTO;
using Microsoft.AspNetCore.Authorization;

namespace Template.Cadastro.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Cadastro")]
    [Authorize]
    public class CadastroController : Base.BaseController
    {
        readonly ITemplateService _templateService;
        readonly ITemplateRepository _templateRepository;
        readonly IMapper _mapper;

        public CadastroController(ITemplateService templateService,
                                  ITemplateRepository templateRepository,
                                  IHandler<DomainNotification> domainNotificationHandler,
                                  IMapper mapper
                                 )
            : base(domainNotificationHandler)
        {
            _templateService = templateService;
            _templateRepository = templateRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Templates")]
        public IActionResult Post([FromBody]Paginacao paginacao = null)
        {
            try
            {
                var templates = _templateRepository.Listar(new PesquisaTemplate(), paginacao).ToList();

                var templatesViewModel = _mapper.Map<IEnumerable<TemplateViewModel>>(templates);

                return Ok(new TemplatePaginadoViewModel { Templates = templatesViewModel, Paginacao = paginacao });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { sucesso = false, erros = new string[] { "Ocorreu um erro ao tentar obter os dados" } });
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var template = _templateRepository.Buscar(id);

                return Ok(_mapper.Map<TemplateViewModel>(template));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { sucesso = false, erros = new string[] { "Ocorreu um erro ao tentar obter os dados" } });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] TemplateViewModel viewModel)
        {
            if (!ValidarModelState())
                return Resposta();

            var template = _mapper.Map<TemplateEntidade>(viewModel);

            viewModel = _mapper.Map<TemplateViewModel>(_templateService.Cadastrar(template));

            return Resposta(viewModel);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] TemplateViewModel viewModel)
        {
            if (!ValidarModelState())
                return Resposta();

            var template = _mapper.Map<TemplateEntidade>(viewModel);

            viewModel = _mapper.Map<TemplateViewModel>(_templateService.Alterar(template));

            return Resposta(viewModel);
        }


        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _templateService.Remover(id);

            return Resposta();
        }
    }
}