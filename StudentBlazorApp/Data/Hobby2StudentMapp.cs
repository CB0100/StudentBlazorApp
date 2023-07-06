using System.ComponentModel.DataAnnotations.Schema;

namespace StudentBlazorApp.Data;

public partial class Hobby2StudentMapp
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int HobbyId { get; set; }

    [NotMapped]
    public bool IsChecked { get; set; }
}