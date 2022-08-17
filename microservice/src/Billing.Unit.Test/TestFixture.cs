using Business.Interfaces;
using DataAccess.Config;
using DataAccess.Context;
using Models.Filters;
using Models.Infrastructure;
using Moq;

namespace Billing.Unit.Test
{
    public class TestFixture
    {

        public readonly Mock<MongoDbContext> _contextMock;
        public readonly Mock<IBillingService> _billingService;

        public TestFixture()
        {
            var settings = new BillingDatabaseSettings()
            {
                ConnectionString = "mongodb://tes123 ",
                DatabaseName = "TestDB",
                CollectionName = "Test"
            };

            _contextMock = new Mock<MongoDbContext>(settings);
            
            _billingService = new Mock<IBillingService>();

            _billingService.Setup(b => b.Create(It.IsAny<Models.Business.Billing>())).Returns(Task.FromResult(new Models.Business.Billing()));

            List<Models.Business.Billing> billings = new List<Models.Business.Billing>
            { 
                new Models.Business.Billing
                {
                    CPF = "456.462.300-12",
                    DueDate = DateTime.Now,
                    ChargeAmount = 1234
                }
            };

            PagedList<Models.Business.Billing> list = new PagedList<Models.Business.Billing>(billings, billings.Count, 0, billings.Count);
            
            _billingService.Setup(b => b.Get(It.IsAny<BillingFilter>())).Returns(list);
        }
    }
}
