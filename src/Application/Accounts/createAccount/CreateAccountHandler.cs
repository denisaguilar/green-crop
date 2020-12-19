using GreenCrop.Application.Common.Interfaces;
using GreenCrop.Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GreenCrop.Application.Accounts.CreateAccount {
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, string> {
        private readonly IAccountCreationService accountCreationService;
        private readonly ICustomerRetrievalService customerRetrievalService;
        private readonly ITransactionCreationService transactionCreationService;

        public CreateAccountHandler(
            IAccountCreationService accountCreation,
            ICustomerRetrievalService customerRetrieval,
            ITransactionCreationService transactionCreation) {
            accountCreationService = accountCreation;
            customerRetrievalService = customerRetrieval;
            transactionCreationService = transactionCreation;
        }

        public async Task<string> Handle(CreateAccountCommand request, CancellationToken cancellationToken) {
            var customer = customerRetrievalService.Retrieve(request.CustomerID);
            if (customer == null) {
                throw new Exception("Customer Id not found");
            }
            var account = customer.Account;
            if (account == null) {
                account = await accountCreationService.Create(customer, cancellationToken);
            }            
            if (request.InitialCredit != 0) {
                await transactionCreationService.SetInitialBalance(account, request.InitialCredit, cancellationToken);
            }
            return account.Id.ToString();
        }
    }
}