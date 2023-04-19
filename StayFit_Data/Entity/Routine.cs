namespace StayFit.StayFit_Data.Entity;

public class Routine:ISoftDelete
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public BodyType BodyType { get; set; }
    public RoutineType RoutineType{ get; set; }
    public int DateTime{ get; set; }
    
    
    public ICollection<User> Users { get; set; }
    
    public ICollection<Exercice> Exercices { get; set; }
    
    public bool IsDeleted { get; set; }
}