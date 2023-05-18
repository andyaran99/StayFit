namespace StayFit.StayFit_Data.Entity;

public class Exercice
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int DateTime { get; set; }
    public ICollection<Routine> Routines { get; set; }
}