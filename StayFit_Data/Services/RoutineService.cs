using StayFit.StayFit_Data.Repositories;
using StayFit.StayFit_Data.Entity;
using StayFit.StayFit_Data.Model.RoutineDTO;
using StayFit.StayFit_Data.Model.ExerciceDTO;
using StayFit.StayFit_Data.Extension;

namespace StayFit.StayFit_Data.Services;

public class RoutineService
{
    private readonly IRepository<Routine> _routineRepository;

    public RoutineService(IRepository<Routine> routineRepository)
    {
        _routineRepository = routineRepository;
    }
    public async Task<List<RoutineViewDto>> ListRoutine()
    {
        var routine = await _routineRepository.GetAll();
        return routine.ToListRoutineViewDto();
    }
    
    public async Task<Routine> NewRoutine(RoutineCreateDto newDetails)
    {
        var detailEntity = newDetails.ToRoutineEntity();
        await _routineRepository.Add(detailEntity);
        return detailEntity;
    }

    public async Task DeleteRoutine(int detailId)
    {
        await _routineRepository.Delete(detailId);
    }

    public async Task<RoutineViewDto> GetById(int routineId)
    {
        var routine = await _routineRepository.Get(routineId);
        return routine.ToRoutineViewDto();
    }
}