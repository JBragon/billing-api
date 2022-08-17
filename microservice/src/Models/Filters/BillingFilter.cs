using LinqKit;
using Models.Business;
using System.Linq.Expressions;

namespace Models.Filters
{

    public class BillingFilter : Filter
    {
        public string? CPF { get; set; }
        public DateTime? DueDate { get; set; }

        private Expression<Func<Billing, bool>> filter = PredicateBuilder.New<Billing>(true);

        public Expression<Func<Billing, bool>> GetFilter()
        {
            if (!string.IsNullOrWhiteSpace(CPF))
                filter = filter.And(x => x.CPF == CPF);

            if (DueDate is not null)
                filter = filter.And(x => x.DueDate == DueDate);

            return filter;
        }

    }
}
