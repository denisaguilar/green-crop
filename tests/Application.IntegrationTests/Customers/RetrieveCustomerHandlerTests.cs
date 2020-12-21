using FluentAssertions;
using GreenCrop.Application.Common.Exceptions;
using GreenCrop.Application.Common.Interfaces;
using GreenCrop.Application.Customers.retrieveCustomer;
using System.Threading.Tasks;
using Xunit;

namespace Application.IntegrationTests.Customers {
    public class RetrieveCustomerHandlerTests : TestBase {
        private TestHelper helper;
        public RetrieveCustomerHandlerTests() {
            helper = new TestHelper(ScopeFactory);
        }   

        [Fact]
        public async Task ShouldRetrieveCustomer() {
            //given
            var command = new RetrieveCustomerCommand {
                CustomerId = "74ff61a7-dcbd-4438-9775-7e1a5ad26261"
            };

            //when
            var customerDetails = await helper.SendAsync(command);

            //then
            customerDetails.Id.Should().Be(command.CustomerId);
            customerDetails.Name.Should().Be("John");
            customerDetails.Surname.Should().Be("Doe");
        }

        [Fact]
        public void ShoultThrowExceptionWhenCustomerNotFound() {
            //given
            var command = new RetrieveCustomerCommand {
                CustomerId = "5597047a-1006-4054-880b-7238889df259"
            };

            //then
            FluentActions.Invoking(() => helper.SendAsync(command))
                .Should().Throw<NotFoundException>();
        }

        [Fact]        
        public void ShouldThrowValidationExceptionWhenInvalidRequest() {
            //given
            var command = new RetrieveCustomerCommand {
                CustomerId = "invalidGuid"
            };

            //then
            FluentActions.Invoking(() => helper.SendAsync(command))
                .Should().Throw<ValidationException>();
        }
    }
}
