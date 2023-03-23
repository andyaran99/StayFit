namespace StayFit.StayFit_Data.Entity;

public interface ISoftDelete
{
    public bool IsDeleted { get; set; }
}