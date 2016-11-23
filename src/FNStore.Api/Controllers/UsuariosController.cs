using FNStore.Domain.Commands;
using FNStore.Domain.Commands.UsuarioCommands;
using FNStore.Domain.Contracts.Repositories;
using FNStore.Domain.Contracts.Transaction;
using FNStore.Service.UsuarioServices;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FNStore.Api.Controllers
{
    [Route("api/v1/usuarios")]
    public class UsuariosController : BaseController
    {
        private readonly IUsuarioRepository _usuarioRepo;

        public UsuariosController(IUnitOfWork uow, IUsuarioRepository usuarioRep) : base(uow)
        {
            _usuarioRepo = usuarioRep;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _usuarioRepo.Get();
            return Ok(usuarios);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var usuarios = _usuarioRepo.Get(id);
            return Ok(usuarios);
        }

        [HttpPost]
        public IActionResult Post([FromBody]RegistrarUsuarioCommand command)
        {
            var service = new RegistrarUsuarioService(command, _usuarioRepo);
            return ReturnResponse(service, new { message = "Usuário cadastrado com sucesso" }, null);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(Guid id, [FromBody]AtualizarUsuarioCommand command)
        {
            command.Id = id;
            var service = new AtualizarUsuarioService(command, _usuarioRepo);
            return ReturnResponse(service, new { message = "Usuário atualizado com sucesso" }, null);
        }
    }
}
