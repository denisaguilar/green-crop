using GreenCrop.Application.Common.Interfaces;
using GreenCrop.Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GreenCrop.Application.Accounts.CreateAccount {
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, string> {
        private readonly IAccountCreateService _accountCreation;

        public CreateAccountHandler(IAccountCreateService accountCreation, ICustomerRetrieveService customerRetrieve, ITransactionCreateService transactionCreate) {
            _accountCreation = accountCreation;
        }

        public async Task<string> Handle(CreateAccountCommand request, CancellationToken cancellationToken) {



            return null;
        }
    }
}