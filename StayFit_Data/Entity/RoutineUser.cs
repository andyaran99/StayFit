namespace StayFit.StayFit_Data.Entity;

public class RoutineUser:ISoftDelete
{
    public int  UserId { get; set; }
    public int RoutineId { get; set; }
    
    public User User { get; set; }
    
    public Routine Routine { get; set; }
    public bool IsDeleted { get; set; }
}