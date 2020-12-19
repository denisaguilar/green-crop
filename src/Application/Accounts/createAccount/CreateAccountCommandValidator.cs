using FluentValidation;

namespace GreenCrop.Application.Accounts.CreateAccount {
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand> {

        private const string GuidRegexPattern = @"(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}";        

        public CreateAccountCommandValidator() {
            RuleFor(c => c.CustomerID)
                .NotEmpty().WithMessage("CustomerId is required")
                .Matches(GuidRegexPattern).WithMessage("CustomerId invalid format");
            RuleFor(c => c.InitialCredit)
                .GreaterThanOrEqualTo(0).WithMessage("Balance should not be negative");
        }
    }
}
