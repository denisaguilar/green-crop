using FluentAssertions;
using GreenCrop.Application.Accounts.CreateAccount;
using GreenCrop.Application.Common.Exceptions;
using GreenCrop.Application.Common.Interfaces;
using NUnit.Framework;
using System.Threading.Tasks;

namespace GreenCrop.Application.IntegrationTests.Accounts {
    using static Testing;
    public class CreateAccountHandlerTests {

        [Test]
        public async Task ShoultCreateAccountWithTransaction() {
            //given
            var command = new CreateAccountCommand {
                CustomerID = "74ff61a7-dcbd-4438-9775-7e1a5ad26261",
                InitialCredit = 100
            };

            //when
            var accountId = await SendAsync(command);

            //then
            var account = await FindAccountAsync(accountId);
            account.CustomerId.Should().Be(command.CustomerID);
            account.Balance.Should().Be(command.InitialCredit);
            account.Transactions.Should().HaveCount(1);
        }

        [Test]
        public async Task ShoultCreateAccountWithoutTransaction() {
            //given
            var command = new CreateAccountCommand {
                CustomerID = "74ff61a7-dcbd-4438-9775-7e1a5ad26261",
                InitialCredit = 0
            };

            //when
            var accountId = await SendAsync(command);

            //then
            var account = await FindAccountAsync(accountId);
            account.CustomerId.Should().Be(command.CustomerID);
            account.Balance.Should().Be(command.InitialCredit);
            account.Transactions.Should().HaveCount(0);
        }

        [Test]
        public void ShoultThrowExceptionWhenCustomerNotFound() {
            //given
            var command = new CreateAccountCommand {
                CustomerID = "5597047a-1006-4054-880b-7238889df259",
                InitialCredit = 100
            };

            //then
            FluentActions.Invoking(() => SendAsync(command))
                .Should().Throw<NotFoundException>();
        }


        [Test]
        [TestCase("invalidGuid", 100)]
        [TestCase("74ff61a7-dcbd-4438-9775-7e1a5ad26261", -1)]
        public void ShouldThrowValidationExceptionWhenInvalidRequest(string customerId, float initialCredit) {
            //given
            var command = new CreateAccountCommand {
                CustomerID = customerId,
                InitialCredit = initialCredit
            };

            //then
            FluentActions.Invoking(() => SendAsync(command))
                .Should().Throw<ValidationException>();
        }
    }

}
