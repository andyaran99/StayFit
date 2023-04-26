using StayFit.StayFit_Data.Entity;

namespace StayFit.StayFit_Data.Model.ExerciceDTO;

public class ExerciceViewDto
{
    public int Id{ get; set; }
    public string Name{ get; set; }
    public string Description{ get; set; }
    public int DateTime { get; set; }
    
    public ICollection<Routine> Routines { get; set; }
}