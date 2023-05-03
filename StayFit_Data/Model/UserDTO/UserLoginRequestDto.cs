using System.ComponentModel.DataAnnotations;
using StayFit.StayFit_Data.Entity;

namespace StayFit.StayFit_Data.Model.UserDTO;


public class UserLoginRequestDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
  
    
    
}