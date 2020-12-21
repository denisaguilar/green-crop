using AutoMapper;
using AutoMapper.QueryableExtensions;
using GreenCrop.Application.Common.Exceptions;
using GreenCrop.Application.Common.Interfaces;
using GreenCrop.Application.Common.Models;
using GreenCrop.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GreenCrop.Application.Customers.retrieveCustomer {
    public class RetrieveCustomerHandler : IRequestHandler<RetrieveCustomerCommand, CustomerDetails> {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RetrieveCustomerHandler(IApplicationDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerDetails> Handle(RetrieveCustomerCommand request, CancellationToken cancellationToken) {
            CustomerDetails customerDetails = await RetrieveCustomer(request, cancellationToken);
            if (customerDetails == null) {
                throw new NotFoundException(nameof(Customer), request.CustomerId);
            }
            return customerDetails;
        }

        private async Task<CustomerDetails> RetrieveCustomer(RetrieveCustomerCommand request, CancellationToken cancellationToken) {
            return await _context.Customers
                .Include(c => c.Accounts)
                .ThenInclude(a => a.Transactions)
                .Where(c => c.Id == request.CustomerId)
                .ProjectTo<CustomerDetails>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
