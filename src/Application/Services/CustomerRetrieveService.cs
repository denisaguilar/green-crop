using GreenCrop.Application.Common.Interfaces;
using GreenCrop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenCrop.Application.Services {
    public class CustomerRetrieveService : ICustomerRetrieveService {
        private readonly IApplicationDbContext _context;
        public CustomerRetrieveService(IApplicationDbContext context) {
            _context = context;
        }

        public Customer Retrieve(string id) {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }
    }
}
