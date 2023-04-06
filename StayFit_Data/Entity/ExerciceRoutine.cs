namespace StayFit.StayFit_Data.Entity;

public class ExerciceRoutine:ISoftDelete
{
    public int ExcerciceId { get; set; }
    public int RoutineId { get; set; }
    
    public Exercice Exercice { get; set; }
    
    public Routine Routine { get; set; }
    public bool IsDeleted { get; set; }
}