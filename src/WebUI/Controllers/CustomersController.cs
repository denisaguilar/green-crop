using GreenCrop.Application.Common.Models;
using GreenCrop.Application.Customers.listCustomers;
using GreenCrop.Application.Customers.retrieveCustomer;
using GreenCrop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenCrop.WebUI.Controllers {
    public class CustomersController : ApiControllerBase {
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDetails>> Get(string id) {
            var command = new RetrieveCustomerCommand {
                CustomerId = id
            };
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerDetails>>> Get() {
            return await Mediator.Send(new ListCustomersCommand());
        }

    }
}
