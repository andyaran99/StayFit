namespace StayFit.StayFit_Data.Entity;

public class User
{
   public int Id { get; set; }
   
   public string Username {get; set;}
   public string Email { get; set; }
   public string Password { get; set; }
   public string FamilyName { get; set; }
   public string LastName { get; set; }
   public BodyType BodyType { get; set; }
   public DateTime DateTime{ get; set; }
   public UserRole UserRole { get; set; }
   public Payment? Payment { get; set; }
   
   public ICollection<Routine> Routines { get; set; }

   
}