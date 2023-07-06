using System.ComponentModel.DataAnnotations.Schema;

namespace StudentBlazorApp.Data
{
    [Table("tblRoles")]
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }
}