using System.ComponentModel.DataAnnotations.Schema;

namespace StudentBlazorApp.Data
{
    [Table("tbl_Course2StudentMapp")]
    public class Course2Student
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int BatchId { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal tax { get; set; }
        public decimal TotalPaid { get; set; }
        public string UPIID { get; set; }
    }
}