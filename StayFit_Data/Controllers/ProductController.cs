using Microsoft.AspNetCore.Authorization;
using StayFit.StayFit_Data.Model.ProductDto;
using StayFit.StayFit_Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace StayFit.StayFit_Data.Controllers;

[Authorize]
[Route("api/Product")]
[ApiController]
public class ProductController:ControllerBase
{
    private readonly ProductService _productService;
    
    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductViewDto>>> GetAll()
    {
        var products = await _productService.ListProducts();
        return products;
    }
    
    [HttpGet("{id}", Name = "GetProductById")]
    public async Task<ActionResult<ProductViewDto>> GetProductById(int id)
    {
        try
        {
            return await _productService.GetById(id);
        }
        catch (InvalidOperationException)
        {
            return NotFound($"Product with ID:{id} not found.");
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<ProductViewDto>> CreateDetails(ProductCreateDto newProduct)
    {
        try
        {
            var createdProduct = await _productService.NewProduct(newProduct);
            return CreatedAtRoute("GetProductById", new { id = createdProduct.Id }, newProduct);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        try
        {
            await _productService.DeleteProduct(id);
            return NoContent();
        }
        catch (InvalidOperationException)
        {
            return NotFound($"Product with ID:{id} not found.");
        }
    }
}