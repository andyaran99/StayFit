using System.ComponentModel.DataAnnotations;
using StayFit.StayFit_Data.Entity;
namespace StayFit.StayFit_Data.Model.UserDTO;

public class UserCreateIdentityDto
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Email { get; set; }
}