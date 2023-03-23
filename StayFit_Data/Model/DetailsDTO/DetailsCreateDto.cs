using System.ComponentModel.DataAnnotations;
using StayFit.StayFit_Data.Entity;
namespace StayFit.StayFit_Data.Model.DetailsDto;

public class DetailsCreateDto
{
    [Required(ErrorMessage = "Body type  is required")]
    public BodyType BodyType { get; set; }
    [Required(ErrorMessage = "Routine Type  is required")]
    public RoutineType RoutineType { get; set; }
    [Required(ErrorMessage = "Date Time  is required")]
    public DateTime DateTime{ get; set; }
    
    
}