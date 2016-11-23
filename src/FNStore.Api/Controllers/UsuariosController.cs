using FNStore.Domain.Commands;
using FNStore.Domain.Contracts.Repositories;
using FNStore.Domain.Contracts.Transaction;
using FNStore.Service.UsuarioServices;
using Microsoft.AspNetCore.Mvc;

namespace FNStore.Api.Controllers
{
    [Route("api/v1/usuarios")]
    public class UsuariosController : BaseController
    {
        private readonly IUsuarioRepository _usuarioRepo;

        public UsuariosController(IUnitOfWork uow, IUsuarioRepository usuarioRep):base(uow)
        {
            _usuarioRepo = usuarioRep;
        }

        [HttpPost]
        public IActionResult Post([FromBody]RegistrarUsuarioCommand command) {

            var service = new RegistrarUsuarioService(command,_usuarioRepo);

            return ReturnResponse(service, new { message = "Usuário cadastrado com sucesso" }, null);
        }
    }
}
