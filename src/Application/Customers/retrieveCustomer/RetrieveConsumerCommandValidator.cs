using FluentValidation;
using GreenCrop.Application.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenCrop.Application.Customers.retrieveCustomer {
    public class RetrieveConsumerCommandValidator : AbstractValidator<RetrieveCustomerCommand> {

        public RetrieveConsumerCommandValidator() {
            RuleFor(c => c.CustomerId)
                    .Matches(ValidationPatterns.GuidRegexPattern).WithMessage("invalid format");
        }
    }
}
