using GreenCrop.Application.Common.Interfaces;
using GreenCrop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GreenCrop.Application.Services {
    public class AccountCreateService : IAccountCreationService {

        private readonly IApplicationDbContext _context;
        public AccountCreateService(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<Account> Create(Customer customer, CancellationToken cancellationToken) {
            var account = new Account {
                Customer = customer                
            };
            var createdAccount = _context.Accounts.Add(account).Entity;            
            await _context.SaveChangesAsync(cancellationToken);            
            return createdAccount;
        }
    }
}
