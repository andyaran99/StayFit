using System.ComponentModel.DataAnnotations;
using StayFit.StayFit_Data.Entity;

namespace StayFit.StayFit_Data.Model.RoutineDTO;

public class RoutineCreateDto
{
    [Required(ErrorMessage = "BodyType type  is required")]
    public BodyType BodyType { get; set; }
    
    [Required(ErrorMessage = "RoutineType type  is required")]
    public RoutineType RoutineType{ get; set; }
    
    [Required(ErrorMessage = "DateTime type  is required")]
    public DateTime DateTime{ get; set; }
}