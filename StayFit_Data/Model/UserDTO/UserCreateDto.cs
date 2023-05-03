using System.ComponentModel.DataAnnotations;
using StayFit.StayFit_Data.Entity;

namespace StayFit.StayFit_Data.Model.UserDTO
{
    public class UserCreateDto
    {
        [Required]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "Username must be between 4 and 32 characters long")]
        public string Username { get; set; }
        [Required]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 32 characters long")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 32 characters long")]
        public string LastName { get; set; }
        [Required]
        
        public string Password { get; set; }
        [Required]
        public UserRole UserRole { get; set; }
        
        [Required]
        public BodyType BodyType { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        
    }
}