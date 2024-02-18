namespace CSIMedia.Dtos;

public class Number
{
    public int Id { get; set; }
    public int[] Numbers { get; set; } = null!;
    public bool Ascending { get; set; }
    public TimeSpan TimeTakenToSort { get; set; }
}
