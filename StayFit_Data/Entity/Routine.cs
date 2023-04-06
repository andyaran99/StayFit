namespace StayFit.StayFit_Data.Entity;

public class Routine:ISoftDelete
{
    public int Id { get; set; }
    public BodyType BodyType { get; set; }
    public RoutineType RoutineType{ get; set; }
    public DateTime DateTime{ get; set; }
    
    
    
    public List<User> UserList { get; set; }
    public List<Exercice> ExercicesList { get; set; }
    
    public bool IsDeleted { get; set; }
}