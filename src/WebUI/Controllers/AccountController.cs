using GreenCrop.Application.Accounts.CreateAccount;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GreenCrop.WebUI.Controllers {
    public class AccountController : ApiControllerBase {
        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateAccountCommand command) {
            return await Mediator.Send(command);
        }
    }
}