using StayFit.StayFit_Data.Entity;

namespace StayFit.StayFit_Data.Model.RoutineDTO;

public class RoutineViewDto
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public BodyType BodyType { get; set; }
    public RoutineType RoutineType{ get; set; }
    public int DateTime{ get; set; }
}