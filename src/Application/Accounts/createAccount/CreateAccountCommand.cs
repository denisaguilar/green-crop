using GreenCrop.Application.Common.Models;
using MediatR;

namespace GreenCrop.Application.Accounts.CreateAccount {
    public class CreateAccountCommand : IRequest<AccountCreationResponse> {
        public string CustomerID { get; set; }
        public float InitialCredit { get; set; }
    }
}
