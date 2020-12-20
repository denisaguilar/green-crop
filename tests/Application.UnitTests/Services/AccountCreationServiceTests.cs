using FluentAssertions;
using GreenCrop.Application.Common.Exceptions;
using GreenCrop.Application.Services;
using GreenCrop.Infrastructure.Persistence;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Services {


    public class AccountCreationServiceTests : TestBase {

        public AccountCreationServiceTests() { }

        [Fact]
        public async Task ShouldCreateAccount() {
            //given
            using var context = new ApplicationDbContext(ContextOptions);
            var accountCreationService = new AccountCreationService(context);

            var customerId = "cea42e0d-feab-496b-8c9e-97bbc25f6230";

            //when
            var account = await accountCreationService.Create(customerId);

            //then
            account.Id.Should().NotBeEmpty();
            account.Customer.Id.Should().Be(customerId);
            account.Transactions.Should().BeNullOrEmpty();
        }

        [Fact]
        public void ShouldThrowNotFoundExceptionWhenCustomerNotFound() {
            //given
            using var context = new ApplicationDbContext(ContextOptions);
            var accountCreationService = new AccountCreationService(context);

            var customerId = "cca320f5-9e5f-49c2-83a7-d0ed9a3d32b2";

            //then
            FluentActions.Invoking(() => accountCreationService.Create(customerId))
                .Should().Throw<NotFoundException>();
        }
    }
}
