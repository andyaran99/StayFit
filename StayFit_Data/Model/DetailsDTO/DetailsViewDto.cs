using StayFit.StayFit_Data.Entity;
namespace StayFit.StayFit_Data.Model.DetailsDto;

public class DetailsViewDto
{
    public int Id { get; set; }
    public BodyType BodyType { get; set; }
    public RoutineType RoutineType{ get; set; }
    public DateTime DateTime{ get; set; }
}