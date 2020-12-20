using FluentValidation;

namespace GreenCrop.Application.Accounts.CreateAccount {
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand> {

        private const string GuidRegexPattern = @"(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}";        

        public CreateAccountCommandValidator() {
            RuleFor(c => c.CustomerID)
                .NotEmpty().WithMessage("field is required")
                .Matches(GuidRegexPattern).WithMessage("invalid format");
            RuleFor(c => c.InitialCredit)
                .GreaterThanOrEqualTo(0).WithMessage("the value should not be negative");
        }
    }
}
