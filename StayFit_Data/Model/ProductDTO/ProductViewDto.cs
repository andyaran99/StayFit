using StayFit.StayFit_Data.Entity;
namespace StayFit.StayFit_Data.Model.ProductDto;

public class ProductViewDto
{
    public int Id{ get; set; }
    public string Title{ get; set; }
    public string Description{ get; set; }
    public double Price{ get; set; }
}