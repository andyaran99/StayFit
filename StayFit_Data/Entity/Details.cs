namespace StayFit.StayFit_Data.Entity;

public class Details:ISoftDelete
{
    public int Id { get; set; }
    public BodyType BodyType { get; set; }
    public RoutineType RoutineType{ get; set; }
    public DateTime DateTime{ get; set; }
    
    public bool IsDeleted { get; set; }
}