namespace StayFit.StayFit_Data.Entity;

public class Product:ISoftDelete
{
    public int Id{ get; set; }
    public string Name{ get; set; }
    public string Description{ get; set; }
    public double Price{ get; set; }
    
    public bool IsDeleted { get; set; }
    
}