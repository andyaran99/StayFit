namespace StayFit.StayFit_Data.Entity;

public class Payment:ISoftDelete
{
    public int Id { get; set; }
    public string CardNumber { get; set;}
    public string ExpMonth { get; set; }
    public string ExpYear { get; set; }
    public string CVV { get; set; }
    
    public bool IsDeleted { get; set; }
}