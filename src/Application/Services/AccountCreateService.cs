using GreenCrop.Application.Common.Interfaces;
using GreenCrop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenCrop.Application.Services {
    public class AccountCreateService : IAccountCreateService {

        private readonly IApplicationDbContext _context;
        public AccountCreateService(IApplicationDbContext context) {
            _context = context;
        }

        public Account Create(Customer customer) {
            var account = new Account {                 
                CustomerId = customer.Id                
            }


            return Account;
        }
    }
}
