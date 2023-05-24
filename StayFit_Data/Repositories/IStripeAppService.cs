using System;
using StayFit.StayFit_Data.Model.Stripe;

namespace StayFit.StayFit_Data.Repositories
{
    public interface IStripeAppService
    {
        Task<StripeCustomer> AddStripeCustomerAsync(AddStripeCustomer customer, CancellationToken ct);
        Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken ct);
    }
}

