using CSIMedia.Dtos;

namespace CSIMedia.Models;

public class IndexModel
{
    public List<Number> Numbers { get; set; } = [];
    public (bool Error, string? Message) ValidationResult { get; set; }
}
