using StayFit.StayFit_Data.Model.RoutineDTO;
using StayFit.StayFit_Data.Extension;
using StayFit.StayFit_Data.Services;
using Microsoft.AspNetCore.Mvc;
using StayFit.StayFit_Data.Entity;
using StayFit.StayFit_Data.Model.ExerciceDTO;

namespace StayFit.StayFit_Data.Controllers;

[Route("api/Routine")]
[ApiController]

public class RoutineController:ControllerBase
{
    private readonly RoutineService _routineService;
    
    
    
    public RoutineController(RoutineService routineService)
    {
        _routineService = routineService;
    }

    [HttpGet]
    public async Task<ActionResult<List<RoutineViewDto>>> GetAll()
    {
        var message = await _routineService.ListRoutine();
        return message;
    }
    
    /*[HttpGet("{id}/exercices", Name = "GetAllRoutineExercices")]
    public async Task<ActionResult<List<ExerciceViewDto>>>GetALLRoutineExercice( int routineId)
    {
        var message = await _routineService.GetAllRoutineExercice(routineId);
        return message;
    }*/
    

    [HttpGet("{id}", Name = "GetRoutineById")]
    public async Task<ActionResult<RoutineViewDto>> GetRoutineById(int id)
    {
        try
        {
            return await _routineService.GetById(id);
        }
        catch (InvalidOperationException)
        {
            return NotFound($"Routine with ID:{id} not found.");
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<RoutineViewDto>> CreateRoutine(RoutineCreateDto newRoutine)
    {
        try
        {
            var createdRoutine = await _routineService.NewRoutine(newRoutine);
            return CreatedAtRoute("GetRoutineId", new { id = createdRoutine.Id }, newRoutine);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteRoutine(int id)
    {
        try
        {
            await _routineService.DeleteRoutine(id);
            return NoContent();
        }
        catch (InvalidOperationException)
        {
            return NotFound($"Routine with ID:{id} not found.");
        }
    }
}