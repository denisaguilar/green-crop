using GreenCrop.Application.Common.Exceptions;
using GreenCrop.Application.Common.Interfaces;
using GreenCrop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GreenCrop.Application.Services {
    public class AccountCreationService : IAccountCreationService {

        private readonly IApplicationDbContext _context;
        public AccountCreationService(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<Account> Create(string customerId, CancellationToken cancellationToken = new CancellationToken()) {
            Customer customer = RetrieveCustomer(customerId);
            var account = new Account {
                Customer = customer
            };
            var createdAccount = _context.Accounts.Add(account).Entity;
            await _context.SaveChangesAsync(cancellationToken);
            return createdAccount;
        }

        private Customer RetrieveCustomer(string customerId) {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == null) {
                throw new NotFoundException(nameof(Customer), customerId);
            }
            return customer;
        }
    }
}
