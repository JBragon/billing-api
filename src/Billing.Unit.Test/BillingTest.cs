using Business.Interfaces;
using Moq;
using Xunit;
using Models.Filters;
using Models.Infrastructure;

namespace Billing.Unit.Test
{
    public class BillingTest
    {
        private readonly Mock<IBillingService> _billingService;

        public BillingTest()
        {
            var fixture = new TestFixture();

            _billingService = fixture._billingService;
        }

        [Fact]
        public async Task Billing_Create_Success()
        {
            var billing = new Models.Business.Billing()
            {
                CPF = "456.462.300-12",
                DueDate = DateTime.Now,
                ChargeAmount = 1234
            };

            var result = await _billingService.Object.Create(billing);

            Assert.NotNull(result);
            Assert.IsType<Models.Business.Billing>(result);
        }

        [Fact]
        public async Task Billing_Create_False()
        {
            var billing = new Models.Business.Billing()
            {
                CPF = "456.462.300-12",
                DueDate = DateTime.Now,
                ChargeAmount = 1234
            };

            var result = await _billingService.Object.Create(billing);

            Assert.Null(result.Id);
            Assert.IsType<Models.Business.Billing>(result);
        }

        [Fact]
        public void Billing_Get_Success()
        {
            BillingFilter filter = new BillingFilter
            {
                CPF = "456.462.300-12"
            };

            var result = _billingService.Object.Get(filter);

            Assert.True(result.Any());
            Assert.IsType<PagedList<Models.Business.Billing>>(result);
        }
    }
}
