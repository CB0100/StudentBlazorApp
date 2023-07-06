using System.ComponentModel.DataAnnotations.Schema;

namespace StudentBlazorApp.Data;

public partial class Country
{
    public int CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    [NotMapped]
    public TblStudent student { get; set; }

    [NotMapped]
    public State States { get; set; }

    [NotMapped]
    public bool IsSeelcted { get; set; }
}