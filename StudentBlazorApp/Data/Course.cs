using System.ComponentModel.DataAnnotations.Schema;

namespace StudentBlazorApp.Data
{
    [Table("tblCourse")]
    public class Course
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; } = string.Empty;
        public int SpecId { get; set; }
        public decimal Fees { get; set; }
        public bool LiveClass { get; set; }
        public bool RecordedClass { get; set; }
        public bool MockTest { get; set; }
        public bool DoubtSolvingSession { get; set; }
        public bool DPP { get; set; }
    }
}