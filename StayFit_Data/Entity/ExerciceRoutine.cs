namespace StayFit.StayFit_Data.Entity;

public class ExerciceRoutine:ISoftDelete
{
    public int ExcerciceId { get; set; }
    
    public int RoutineId { get; set; }
    public bool IsDeleted { get; set; }
}