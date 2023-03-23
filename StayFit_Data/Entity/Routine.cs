namespace StayFit.StayFit_Data.Entity;

public class Routine:ISoftDelete
{
    public int Id { get; set; }
    public Details Details { get;set; }
    public User? Trainer{ get; set; }
    
    public List<User>AttendingMembers { get; set; }
    public List<Exercice> ExercicesList { get; set; }
    
    public bool IsDeleted { get; set; }
}