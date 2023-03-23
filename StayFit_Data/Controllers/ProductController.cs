using StayFit.StayFit_Data.Extension;
using StayFit.StayFit_Data.Model.ProductDto;
using StayFit.StayFit_Data.Entity;
using StayFit.StayFit_Data.Repositories;
using StayFit.StayFit_Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace StayFit.StayFit_Data.Controllers;

public class ProductController
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
}