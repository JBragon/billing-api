using Billing.Integration.Test.Utils;
using Microsoft.AspNetCore.Mvc.Testing;
using Models.Mapper.Request;
using Newtonsoft.Json;
using System.Net.Http.Json;
using Xunit;

namespace Billing.Integration.Test
{
    public class BillingAPITest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public BillingAPITest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_Billing_Success()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/api/Billing");

            var billings = await response.ReadContentAs<List<Models.Business.Billing>>();

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299

            Assert.NotNull(billings);
            Assert.IsType<List<Models.Business.Billing>>(billings);
        }

        [Theory]
        [InlineData(1234)]
        [InlineData(3245)]
        [InlineData(4568)]
        [InlineData(5735)]
        [InlineData(4587)]
        [InlineData(5853)]
        [InlineData(5785)]
        [InlineData(8145)]
        public async Task Create_Billing_Success(decimal chargeAmount)
        {
            // Arrange
            var client = _factory.CreateClient();

            BillingPost post = new BillingPost
            {
                CPF = CPFUtils.GerarCpf(),
                DueDate = DateTime.Now,
                ChargeAmount = chargeAmount
            };

            // Act
            var response = await client.PostAsJsonAsync($"/api/Billing", post);

            var billingRegistered = await response.ReadContentAs<Models.Business.Billing>();

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299

            Assert.NotNull(billingRegistered);
            Assert.IsType<Models.Business.Billing>(billingRegistered);

        }

        [Fact]
        public async Task Create_Billing_Error()
        {
            // Arrange
            var client = _factory.CreateClient();

            BillingPost post = new BillingPost
            {
                CPF = Guid.NewGuid().ToString().Substring(0, 11),
                DueDate = DateTime.Now,
                ChargeAmount = 1234
            };

            // Act
            var response = await client.PostAsJsonAsync($"/api/Billing", post);

            // Assert
            Assert.False(response.IsSuccessStatusCode);
        }
    }
}
