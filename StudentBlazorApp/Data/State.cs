using System.ComponentModel.DataAnnotations.Schema;

namespace StudentBlazorApp.Data;

public partial class State
{
    public int StateId { get; set; }

    public string StateName { get; set; } = null!;

    public int CountryId { get; set; }

    [NotMapped]
    public bool IsSelected { get; set; }
}