namespace StayFit.StayFit_Data.Model.UserDTO;
using StayFit.StayFit_Data.Entity;

public class UserViewDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
    
    public BodyType BodyType { get; set; }
    
    public string Email { get; set; }
    
    public UserRole UserRole { get; set; }
}