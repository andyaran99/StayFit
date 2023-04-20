namespace StayFit.StayFit_Data.Entity;

public class Routine
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string BodyType { get; set; }
    public string RoutineType{ get; set; }
    public int DateTime{ get; set; }
    
    
    public ICollection<User> Users { get; set; }
    
    public ICollection<Exercice> Exercices { get; set; }
    
   
}