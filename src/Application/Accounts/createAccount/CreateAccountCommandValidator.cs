using FluentValidation;
using GreenCrop.Application.Common.Constants;

namespace GreenCrop.Application.Accounts.CreateAccount {
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand> {
        
        public CreateAccountCommandValidator() {
            RuleFor(c => c.CustomerID)
                .NotEmpty().WithMessage("field is required")
                .Matches(ValidationPatterns.GuidRegexPattern).WithMessage("invalid format");
            RuleFor(c => c.InitialCredit)
                .GreaterThanOrEqualTo(0).WithMessage("the value should not be negative");
        }
    }
}
