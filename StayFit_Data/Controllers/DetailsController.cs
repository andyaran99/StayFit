using StayFit.StayFit_Data.Extension;
using StayFit.StayFit_Data.Model.DetailsDto;
using StayFit.StayFit_Data.Entity;
using StayFit.StayFit_Data.Repositories;
using StayFit.StayFit_Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;



namespace StayFit.StayFit_Data.Controllers;

public class DetailsController:ControllerBase
{
    private readonly DetailsService _detailsService;
    public DetailsController(DetailsService productService)
    {
        _detailsService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<List<DetailsViewDto>>> GetAll()
    {
        var products = await _detailsService.ListProducts();
        return products;
    }

    /*[HttpGet("{id}", Name = "GetProductById")]
    public async Task<ActionResult<DetailsViewDto>> GetProductById(int id)
    {
        try
        {
            return await _detailsService.GetById(id);
        }
        catch (InvalidOperationException)
        {
            return NotFound($"Product with ID:{id} not found.");
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<DetailsViewDto>> CreateDetails(DetailsCreateDto newProduct)
    {
        try
        {
            var createdProduct = await _detailsService.NewDetails(newProduct);
            return CreatedAtRoute("GetProductById", new { id = createdProduct.Id }, newProduct);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        try
        {
            await _detailsService.DeleteDetail(id);
            return NoContent();
        }
        catch (InvalidOperationException)
        {
            return NotFound($"Product with ID:{id} not found.");
        }
    }*/
}