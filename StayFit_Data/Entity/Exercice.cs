namespace StayFit.StayFit_Data.Entity;

public class Exercice:ISoftDelete
{
    public int Id { get; set; }
    public string Name{ get; set; }
    public string Description{ get; set; }
    public DateTime DateTime{ get; set; }
    
    public List<Routine> RoutineList { get; set; }

    public bool IsDeleted { get; set; }
}