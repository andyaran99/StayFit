namespace StayFit.StayFit_Data.Model.UserDTO;
using System.ComponentModel.DataAnnotations;
using StayFit.StayFit_Data.Entity;

public class UserUpdateDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(32, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 32 characters long")]
    public string FirstName { get; set; }
    [Required]
    [StringLength(32, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 32 characters long")]
    public string LastName { get; set; }
    [Required]
    [StringLength(32, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 32 characters long")]
    public string Password { get; set; }
    
    [Required]
    public BodyType BodyType { get; set; }
        
    [Required]
    public string Email { get; set; }
    
    [Required]
    public UserRole UserRole { get; set; }
}