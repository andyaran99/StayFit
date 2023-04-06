using StayFit.StayFit_Data.Repositories;
using StayFit.StayFit_Data.Entity;
using StayFit.StayFit_Data.Model.ExerciceDTO;
using StayFit.StayFit_Data.Extension;


namespace StayFit.StayFit_Data.Services;

public class ExerciceService
{
    private readonly IRepository<Exercice> _exerciceRepository;

    public ExerciceService(IRepository<Exercice> exerciceRepository)
    {
        _exerciceRepository = exerciceRepository;
    }
    public async Task<List<ExerciceViewDto>> ListExercice()
    {
        var exercice = await _exerciceRepository.GetAll();
        return exercice.ToListExerciceViewDto();
    }
    public async Task<Exercice> NewExercice(ExerciceCreateDto newDetails)
    {
        var detailEntity = newDetails.ToExerciceEntity();
        await _exerciceRepository.Add(detailEntity);
        return detailEntity;
    }

    public async Task DeleteExercice(int detailId)
    {
        await _exerciceRepository.Delete(detailId);
    }

    public async Task<ExerciceViewDto> GetById(int exerciceId)
    {
        var exercice = await _exerciceRepository.Get(exerciceId);
        return exercice.ToExerciceViewDto();
    }
}