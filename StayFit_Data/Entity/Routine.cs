namespace StayFit.StayFit_Data.Entity;

public class Routine:ISoftDelete
{
    public int Id { get; set; }
    public BodyType BodyType { get; set; }
    public RoutineType RoutineType{ get; set; }
    public DateTime DateTime{ get; set; }
    
    
    
    public List<User> Users { get; set; }
    
    public List<Exercice> Exercices { get; set; }
    
    public bool IsDeleted { get; set; }
}