using StayFit.StayFit_Data.Entity;
using StayFit.StayFit_Data.Model.ProductDto;
namespace StayFit.StayFit_Data.Extension;

public static class ProductExtension
{
    public static Product ToProductEntity(this ProductViewDto productView)
    {
        return new Product
        {
            Id = productView.Id,
            Description = productView.Description,
            Name = productView.Name,
            Price = productView.Price
            
        };
    }

    public static Product ToProductEntity(this ProductCreateDto productView)
    {
        return new Product
        {
            Description = productView.Description,
            Name = productView.Name,
            Price = productView.Price

        };
    }

    public static ProductViewDto ToProductViewDto(this Product productEntity)
    {
        return new ProductViewDto
        {
            Id = productEntity.Id,
            Description = productEntity.Description,
            Name = productEntity.Name,
            Price = productEntity.Price
        };
    }
    
    public static List<ProductViewDto> ToListProductViewDto(this List<Product> productEntities)
    {
        List<ProductViewDto> result = new List<ProductViewDto>();
        foreach (var productEntity in productEntities)
        {
            result.Add(ToProductViewDto(productEntity));
        }
        return result;
    }
}