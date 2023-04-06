using System.ComponentModel.DataAnnotations;

namespace StayFit.StayFit_Data.Model.ExerciceDTO;

public class ExerciceCreateDto
{
    [Required(ErrorMessage = "Body type  is required")]
    public string Name{ get; set; }
    
    [Required(ErrorMessage = "Body type  is required")]
    public string Description{ get; set; }
    
    [Required(ErrorMessage = "Body type  is required")]
    public DateTime DateTime{ get; set; }
}