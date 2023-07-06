using System.ComponentModel.DataAnnotations.Schema;

namespace StudentBlazorApp.Data;

public partial class City
{
    public int CityId { get; set; }

    public string CityName { get; set; } = null!;

    public int StateId { get; set; }

    [NotMapped]
    public bool IsSelected { get; set; }
}