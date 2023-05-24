﻿using System;
namespace StayFit.StayFit_Data.Model.Stripe
{
    public record AddStripeCard(
        string Name,
        string CardNumber,
        string ExpirationYear,
        string ExpirationMonth,
        string Cvc); 
}

