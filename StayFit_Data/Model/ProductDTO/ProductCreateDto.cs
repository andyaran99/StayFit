using System.ComponentModel.DataAnnotations;
using StayFit.StayFit_Data.Entity;
namespace StayFit.StayFit_Data.Model.ProductDto;


public class ProductCreateDto
{
    [Required(ErrorMessage = "Body type  is required")]
    public string Title{ get; set; }
    [Required(ErrorMessage = "Body type  is required")]
    public string Description{ get; set; }
    [Required(ErrorMessage = "Body type  is required")]
    public double Price{ get; set; }
}