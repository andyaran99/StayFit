using System.ComponentModel.DataAnnotations;
using StayFit.StayFit_Data.Entity;

namespace StayFit.StayFit_Data.Model.UserDTO;


public class UserLoginDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string HashedPassword { get; set; }
    [Required]
    public UserRole Role { get; set; }
    
}