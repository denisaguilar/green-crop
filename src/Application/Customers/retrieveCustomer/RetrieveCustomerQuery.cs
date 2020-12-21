using GreenCrop.Application.Common.Models;
using MediatR;

namespace GreenCrop.Application.Customers.retrieveCustomer {
    public class RetrieveCustomerQuery : IRequest<CustomerDetails> {
        public string CustomerId { get; set; }
    }
}
