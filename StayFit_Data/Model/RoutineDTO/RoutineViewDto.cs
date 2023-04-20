using StayFit.StayFit_Data.Entity;

namespace StayFit.StayFit_Data.Model.RoutineDTO;

public class RoutineViewDto
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string BodyType { get; set; }
    public string RoutineType{ get; set; }
    public int DateTime{ get; set; }
    
    public ICollection<Exercice> Exercices { get; set; }
}