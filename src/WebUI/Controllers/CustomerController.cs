using GreenCrop.Application.Common.Models;
using GreenCrop.Application.Customers.retrieveCustomer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenCrop.WebUI.Controllers {
    public class CustomerController : ApiControllerBase {
        [HttpGet("{customerId}")]
        public async Task<ActionResult<CustomerDetails>> Retrieve(string customerId) {
            var query = new RetrieveCustomerCommand {
                CustomerId = customerId
            };
            return await Mediator.Send(query);
        }
    }
}
