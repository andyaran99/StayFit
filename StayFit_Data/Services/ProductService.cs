using StayFit.StayFit_Data.Repositories;
using StayFit.StayFit_Data.Entity;
using StayFit.StayFit_Data.Model.ProductDto;
using StayFit.StayFit_Data.Extension;


namespace StayFit.StayFit_Data.Services;

public class ProductService
{
    private readonly IRepository<Product> _productRepository;

    public ProductService(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<List<ProductViewDto>> ListProducts()
    {
        var products = await _productRepository.GetAll();
        return products.ToListProductViewDto();
    }
    public async Task<Product> NewDetails(ProductCreateDto newDetails)
    {
        var detailEntity = newDetails.ToProductEntity();
        await _productRepository.Add(detailEntity);
        return detailEntity;
    }

    public async Task DeleteDetail(int detailId)
    {
        await _productRepository.Delete(detailId);
    }

    public async Task<ProductViewDto> GetById(int productId)
    {
        var product = await _productRepository.Get(productId);
        return product.ToProductViewDto();
    }
}