using System.ComponentModel.DataAnnotations;

namespace CSIMedia.Entities;

// ReSharper disable once InconsistentNaming
public class EFNumber
{
    [Key] public int Id { get; set; }

    // I know this stores as a string in the database.
    public int[] Numbers { get; set; } = null!;
    public bool Ascending { get; set; }
    public TimeSpan TimeTakenToSort { get; set; }
}
