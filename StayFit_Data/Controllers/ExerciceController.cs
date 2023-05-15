using StayFit.StayFit_Data.Model.ExerciceDTO;
using StayFit.StayFit_Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace StayFit.StayFit_Data.Controllers;

[Route("api/Exercices")]
[ApiController]
public class ExerciceController:ControllerBase
{
    private readonly ExerciceService _exerciceService;
    
    public ExerciceController(ExerciceService exerciceService)
    {
        _exerciceService = exerciceService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ExerciceViewDto>>> GetAll()
    {
        var message = await _exerciceService.ListExercice();
        return message;
    }
    
    [HttpGet("{id}", Name = "GetExerciceById")]
    public async Task<ActionResult<ExerciceViewDto>> GetExerciceById(int id)
    {
        try
        {
            return await _exerciceService.GetById(id);
        }
        catch (InvalidOperationException)
        {
            return NotFound($"Exercice with ID:{id} not found.");
        }
    }
    
    
    [HttpPost]
    public async Task<ActionResult<ExerciceViewDto>> CreateExercice(ExerciceCreateDto newExercice)
    {
        try
        {
            var createdExercice = await _exerciceService.NewExercice(newExercice);
            return CreatedAtRoute("GetExerciceId", new { id = createdExercice.Id }, newExercice);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteExercice(int id)
    {
        try
        {
            await _exerciceService.DeleteExercice(id);
            return NoContent();
        }
        catch (InvalidOperationException)
        {
            return NotFound($"Exercice with ID:{id} not found.");
        }
    }
}