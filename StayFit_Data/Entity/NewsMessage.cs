namespace StayFit.StayFit_Data.Entity;

public class NewsMessage:ISoftDelete
{
    public int Id{ get; set; }
    public string Title{ get; set; }
    public string Description{ get; set; }
    
    public bool IsDeleted { get; set; }
}