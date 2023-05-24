using System;
namespace StayFit.StayFit_Data.Model.Stripe
{
    public record AddStripeCustomer(
        string Email,
        string Name,
        AddStripeCard CreditCard);
}

