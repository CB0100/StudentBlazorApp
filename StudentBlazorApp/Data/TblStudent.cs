using System.ComponentModel.DataAnnotations;

namespace StudentBlazorApp.Data;

public partial class TblStudent
{
    public int StudentId { get; set; }

    [Required]
    //[MaxLength(10)]
    //[MinLength(10,ErrorMessage ="Minimum 10 Digit required.")]
    public long PhoneNumber { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Email Should be like ****@****.com")]
    public string EmailAddress { get; set; } = null!;

    [Required]
    public string RegistrationId { get; set; } = null!;

    [Required]
    [RegularExpression(@"^[a-zA-Z\s]+$",ErrorMessage ="Only Letters")]
    public string FirstName { get; set; } = null!;

    [Required]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only Letters")]
    public string LastName { get; set; } = null!;

    [Required]
    public string Gender { get; set; } = null!;

    [Required]
    public DateTime Dob { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only Letters")]
    public string FatherName { get; set; } = null!;

    [Required]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only Letters")]
    public string MotherName { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;

    [Required]
    public string Address { get; set; } = null!;

    [Required]
    public int ZipCode { get; set; }

    public int City { get; set; }

    public int State { get; set; }

    public int Country { get; set; }

    public bool IsActive { get; set; }
    public int RoleId { get; set; }
}