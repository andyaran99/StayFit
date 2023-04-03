namespace StayFit.StayFit_Data.Entity;

public class Routine:ISoftDelete
{
    public int Id { get; set; }
    public BodyType BodyType { get; set; }
    public RoutineType RoutineType{ get; set; }
    public DateTime DateTime{ get; set; }
    public User? Trainer{ get; set; }
    public Exercice Exercice { get; set; }
    
    public List<User>AttendingMembers { get; set; }
    public List<Exercice> ExercicesList { get; set; }
    
    public bool IsDeleted { get; set; }
}