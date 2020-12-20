using GreenCrop.Application.Accounts.CreateAccount;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GreenCrop.WebUI.Controllers {
    public class AccountController : ApiControllerBase {
        [HttpPost]
        public async Task<ActionResult> Create(CreateAccountCommand command) {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}