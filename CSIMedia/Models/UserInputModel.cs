
using System.ComponentModel;

namespace CSIMedia.Models;

public class UserInputModel
{
    [DisplayName("Numbers - Use Comma Separated Values")]
    public string RawUserInput { get; init; } = null!;
    public bool Ascending { get; set; }
}
