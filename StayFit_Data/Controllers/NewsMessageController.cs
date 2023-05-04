using StayFit.StayFit_Data.Model.NewsMessageDTO;
using StayFit.StayFit_Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace StayFit.StayFit_Data.Controllers;


[Route("api/Message")]
[ApiController]
public class NewsMessageController:ControllerBase
{
    private readonly NewsMessageService _newsMessageService;
    
    public NewsMessageController(NewsMessageService newsMessageService)
    {
        _newsMessageService = newsMessageService;
    }

    [HttpGet]
    public async Task<ActionResult<List<NewsMessageViewDto>>> GetAll()
    {
        var message = await _newsMessageService.ListProducts();
        return message;
    }
    
    [HttpGet("{id}", Name = "GetNewsMessageById")]
    public async Task<ActionResult<NewsMessageViewDto>> GetNewsMessageById(int id)
    {
        try
        {
            return await _newsMessageService.GetById(id);
        }
        catch (InvalidOperationException)
        {
            return NotFound($"Message with ID:{id} not found.");
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<NewsMessageViewDto>> CreateNewsMessage(NewsMessageCreateDto newNewsMessage)
    {
        try
        {
            var createdNewsMessage = await _newsMessageService.NewNewsMessage(newNewsMessage);
            return CreatedAtRoute("GetNewsMessageId", new { id = createdNewsMessage.Id }, newNewsMessage);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteNewsMessage(int id)
    {
        try
        {
            await _newsMessageService.DeleteNewsMessage(id);
            return NoContent();
        }
        catch (InvalidOperationException)
        {
            return NotFound($"message with ID:{id} not found.");
        }
    }
}