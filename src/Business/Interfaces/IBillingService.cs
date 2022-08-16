using Models.Business;
using Models.Filters;
using Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IBillingService
    {
        Task<Billing> Create(Billing billing);
        PagedList<Billing> Get(BillingFilter filter);
    }
}
