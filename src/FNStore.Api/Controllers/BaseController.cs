using DomainNotificationHelperCore.Commands;
using FNStore.Domain.Contracts.Transaction;
using Microsoft.AspNetCore.Mvc;

namespace FNStore.Api.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUnitOfWork _uow;

        public BaseController(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public IActionResult ReturnResponse(ServerCommand service, object success, object error)
        {
            if (service.HasNotifications())
                return BadRequest(new { success = false, data = error, errors = service.GetNotifications() });

            _uow.Commit();
            return Ok(new { success = true, data = success });
        }
    }
}
