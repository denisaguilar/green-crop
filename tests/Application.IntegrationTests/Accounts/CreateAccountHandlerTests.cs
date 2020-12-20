using Application.IntegrationTests;
using FluentAssertions;
using GreenCrop.Application.Accounts.CreateAccount;
using GreenCrop.Application.Common.Exceptions;
using GreenCrop.Application.Common.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace GreenCrop.Application.IntegrationTests.Accounts {
    public class CreateAccountHandlerTests : IClassFixture<TestHelper> {
        private TestHelper testHelper;

        public CreateAccountHandlerTests(TestHelper helper) {
            testHelper = helper;
        }

        [Fact]
        public async Task ShoultCreateAccountWithTransaction() {
            //given
            var command = new CreateAccountCommand {
                CustomerID = "74ff61a7-dcbd-4438-9775-7e1a5ad26261",
                InitialCredit = 100
            };

            //when
            var accountId = await testHelper.SendAsync(command);

            //then
            var account = await testHelper.FindAccountAsync(accountId);
            account.CustomerId.Should().Be(command.CustomerID);
            account.Balance.Should().Be(command.InitialCredit);
            account.Transactions.Should().HaveCount(1);
        }

        [Fact]
        public async Task ShoultCreateAccountWithoutTransaction() {
            //given
            var command = new CreateAccountCommand {
                CustomerID = "74ff61a7-dcbd-4438-9775-7e1a5ad26261",
                InitialCredit = 0
            };

            //when
            var accountId = await testHelper.SendAsync(command);

            //then
            var account = await testHelper.FindAccountAsync(accountId);
            account.CustomerId.Should().Be(command.CustomerID);
            account.Balance.Should().Be(command.InitialCredit);
            account.Transactions.Should().HaveCount(0);
        }

        [Fact]
        public void ShoultThrowExceptionWhenCustomerNotFound() {
            //given
            var command = new CreateAccountCommand {
                CustomerID = "5597047a-1006-4054-880b-7238889df259",
                InitialCredit = 100
            };

            //then
            FluentActions.Invoking(() => testHelper.SendAsync(command))
                .Should().Throw<NotFoundException>();
        }


        [Theory]
        [InlineData("invalidGuid", 100)]
        [InlineData("74ff61a7-dcbd-4438-9775-7e1a5ad26261", -1)]
        public void ShouldThrowValidationExceptionWhenInvalidRequest(string customerId, float initialCredit) {
            //given
            var command = new CreateAccountCommand {
                CustomerID = customerId,
                InitialCredit = initialCredit
            };

            //then
            FluentActions.Invoking(() => testHelper.SendAsync(command))
                .Should().Throw<ValidationException>();
        }
    }

}
