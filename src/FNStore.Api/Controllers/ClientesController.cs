using FNStore.Domain.Contracts.Repositories;
using FNStore.Domain.Entities;
using FNStore.Infra.Data.EF.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNStore.Api.Controllers
{
    [Route("api/v1/clientes")]
    public class ClientesController : Controller
    {
        private readonly IClienteRepository _repCli;

        public ClientesController(IClienteRepository repCli)
        {
            _repCli = repCli;
        }

        public IEnumerable<Cliente> Get()
        {
            return _repCli.Get().ToList();
        }

        protected override void Dispose(bool disposing)
        {
            _repCli.Dispose();
        }
    }
}
