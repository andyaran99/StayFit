using System.ComponentModel.DataAnnotations;
using StayFit.StayFit_Data.Entity;

namespace StayFit.StayFit_Data.Model.RoutineDTO;

public class RoutineCreateDto
{
    
    [Required(ErrorMessage = "Name type  is required")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "BodyType type  is required")]
    public BodyType BodyType { get; set; }
    
    [Required(ErrorMessage = "RoutineType type  is required")]
    public RoutineType RoutineType{ get; set; }
    
    [Required(ErrorMessage = "DateTime type  is required")]
    public int DateTime{ get; set; }
}