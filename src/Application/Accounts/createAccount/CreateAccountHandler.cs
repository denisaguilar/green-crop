using GreenCrop.Application.Common.Interfaces;
using GreenCrop.Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GreenCrop.Application.Accounts.CreateAccount {
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand> {
        private readonly IAccountCreationService accountCreationService;
        private readonly ITransactionCreationService transactionCreationService;

        public CreateAccountHandler(
            IAccountCreationService accountCreation,
            ITransactionCreationService transactionCreation) {
            accountCreationService = accountCreation;
            transactionCreationService = transactionCreation;
        }

        public async Task<Unit> Handle(CreateAccountCommand request, CancellationToken cancellationToken) {
            var account = await accountCreationService.Create(request.CustomerID, cancellationToken);
            if (request.InitialCredit != 0) {
                await transactionCreationService.SetInitialBalance(account, request.InitialCredit, cancellationToken);
            }
            return Unit.Value;
        }
    }
}