using GreenCrop.Application.Accounts.CreateAccount;
using GreenCrop.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GreenCrop.WebUI.Controllers {
    public class AccountsController : ApiControllerBase {
        [HttpPost]
        public async Task<ActionResult<AccountCreationResponse>> Create(CreateAccountCommand command) {
            return await Mediator.Send(command);            
        }
    }
}