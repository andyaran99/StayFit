using StayFit.StayFit_Data.Entity;
using StayFit.StayFit_Data.Model.ExerciceDTO;

namespace StayFit.StayFit_Data.Extension;

public static class ExerciceExtension
{
    public static Exercice ToExerciceEntity(this ExerciceViewDto exerciceView)
    {
        return new Exercice
        {
            Id = exerciceView.Id,
            Description = exerciceView.Description,
            Name = exerciceView.Name,
            DateTime = exerciceView.DateTime

        };
    }

    public static Exercice ToExerciceEntity(this ExerciceCreateDto exerciceView)
    {
        return new Exercice
        {
            Description = exerciceView.Description,
            Name = exerciceView.Name,
            DateTime = exerciceView.DateTime
            

        };
    }

    public static ExerciceViewDto ToExerciceViewDto(this Exercice exerciceEntity)
    {
        return new ExerciceViewDto
        {
            Id = exerciceEntity.Id,
            Description = exerciceEntity.Description,
            Name = exerciceEntity.Name,
            DateTime = exerciceEntity.DateTime
        };
    }
    
    public static List<ExerciceViewDto> ToListExerciceViewDto(this List<Exercice> exerciceEntities)
    {
        List<ExerciceViewDto> result = new List<ExerciceViewDto>();
        foreach (var exerciceEntity in exerciceEntities)
        {
            result.Add(ToExerciceViewDto(exerciceEntity));
        }
        return result;
    }
}