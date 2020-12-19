using MediatR;

namespace GreenCrop.Application.Accounts.CreateAccount {
    public class CreateAccountCommand : IRequest<string> {
        public string CustomerID { get; set; }
        public float InitialCredit { get; set; }
    }
}
