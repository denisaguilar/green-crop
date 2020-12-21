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

namespace GreenCrop.Application.Customers.listCustomers {
    public class ListCustomersHandler : IRequestHandler<ListCustomersCommand, List<CustomerDetails>> {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ListCustomersHandler(IApplicationDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }      

        public Task<List<CustomerDetails>> Handle(ListCustomersCommand request, CancellationToken cancellationToken) {
            return _context.Customers                          
             .ProjectTo<CustomerDetails>(_mapper.ConfigurationProvider)
             .ToListAsync(cancellationToken);
        }      
    }
}
