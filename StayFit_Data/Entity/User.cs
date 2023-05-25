using Microsoft.AspNetCore.Identity;

namespace StayFit.StayFit_Data.Entity;

public class User:IdentityUser
{
   public string FirstName { get; set; } 
   public string LastName { get; set; }
   public BodyType BodyType { get; set; }
   public UserRole UserRole { get; set; }
   public string StripeAccountId { get; set; }
   public ICollection<Routine> Routines { get; set; }

   
}