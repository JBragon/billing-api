using FluentValidation;
using Models.Business;
using Models.Infrastructure;

namespace Models.Mapper.Request
{
    public class BillingPost
    {
        public string CPF { get; set; }
        public DateTime DueDate { get; set; }
        public decimal ChargeAmount { get; set; }

        public static explicit operator Billing(BillingPost billingPost)
        {
            return new Billing
            {
                CPF = billingPost.CPF,
                DueDate = billingPost.DueDate,
                ChargeAmount = billingPost.ChargeAmount,
            };
        }
    }


    public class BillingPostValidation : AbstractValidator<BillingPost>
    {
        public BillingPostValidation()
        {
            RuleFor(v => v.CPF)
             .NotEmpty()
             .WithMessage(RuleMessage.Informed("{PropertyName}"))
             .IsValidCPF()
             .WithMessage(Resources.Common.InvalidCPF)
             .MaximumLength(14);

            RuleFor(v => v.DueDate)
              .NotEmpty()
              .WithMessage(RuleMessage.Informed("{PropertyName}"));

            RuleFor(v => v.ChargeAmount)
             .NotEmpty()
             .WithMessage(RuleMessage.Informed("{PropertyName}"));

        }
    }
}
