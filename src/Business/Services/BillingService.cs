using Business.Interfaces;
using DataAccess.Context;
using Models.Business;
using Models.Filters;
using Models.Infrastructure;
using MongoDB.Driver;

namespace Business.Services
{
    public class BillingService: IBillingService
        
    {
        private readonly IMongoCollection<Billing> _billings;

        public BillingService(MongoDbContext context)
        {
            _billings = context.Billings;
        }

        public async Task<Billing> Create(Billing billing)
        {
            await _billings.InsertOneAsync(billing);
            return billing;
        }

        public PagedList<Billing> Get(BillingFilter filter)
        {
            var queryable = _billings.AsQueryable()
                .Where(filter.GetFilter())
                .OrderByDescending(b => b.Id);

            return PagedList<Billing>.ToPagedList(queryable, filter.PageNumber, filter.PageSize);
        }
    }
}
