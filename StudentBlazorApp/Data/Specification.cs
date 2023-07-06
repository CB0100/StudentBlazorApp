using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentBlazorApp.Data
{
    [Table("tblSpecification")]
    public class Specification
    {
        [Key]
        public int SpecId { get; set; }

        public string SpecName { get; set; } = string.Empty;
    }
}