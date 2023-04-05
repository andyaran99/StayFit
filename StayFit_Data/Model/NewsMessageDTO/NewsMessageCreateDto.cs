using System.ComponentModel.DataAnnotations;
namespace StayFit.StayFit_Data.Model.NewsMessageDTO;

public class NewsMessageCreateDto
{
    [Required(ErrorMessage = "Body type  is required")]
    public string Title{ get; set; }
    
    [Required(ErrorMessage = "Body type  is required")]
    public string Description{ get; set; }
}