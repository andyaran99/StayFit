using System;
namespace StayFit.StayFit_Data.Model.Stripe
{
   
    public record AddStripePayment(
        string CustomerId,
        string ReceiptEmail,
        string Description,
        string Currency,
        long Amount);
    
}

