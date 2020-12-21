using GreenCrop.Application.Common.Models;
using GreenCrop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenCrop.Application.Customers.listCustomers{
    public class ListCustomersCommand : IRequest<List<CustomerDetails>> {
    }
}
