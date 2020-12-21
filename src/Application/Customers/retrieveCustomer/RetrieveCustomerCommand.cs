using GreenCrop.Application.Common.Models;
using MediatR;

namespace GreenCrop.Application.Customers.retrieveCustomer {
    public class RetrieveCustomerCommand : IRequest<CustomerDetails> {
        public string CustomerId { get; set; }
    }
}
