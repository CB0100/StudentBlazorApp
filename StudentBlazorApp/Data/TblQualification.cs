using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentBlazorApp.Data;

public partial class TblQualification
{
    public int StdQlfId { get; set; }

    [Required]
    public int StudentId { get; set; }

    [Required]
    public string QualifiactionName { get; set; } = null!;

    [Required]
    public string University { get; set; } = null!;

    [Required]
    public int TermYear { get; set; }

    [Required]
    public int CompletationYear { get; set; }

    [Required]
    public decimal Percentage { get; set; }

    [NotMapped]
    public string decimalpercentage { get; set; }
}