using System.ComponentModel.DataAnnotations.Schema;

namespace StudentBlazorApp.Data;

public partial class Hobby
{
    public int HobbyId { get; set; }

    public string HobbyName { get; set; } = null!;

    [NotMapped]
    public bool isselected { get; set; } = false;
}