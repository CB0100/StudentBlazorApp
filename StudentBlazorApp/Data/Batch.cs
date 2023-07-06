using System.ComponentModel.DataAnnotations.Schema;

namespace StudentBlazorApp.Data
{
    [Table("tblBatch")]
    public class Batch
    {
        public int BatchId { get; set; }
        public string BatchName { get; set; } = string.Empty;
        public TimeSpan BatchStartTime { get; set; }
        public TimeSpan BatchEndTime { get; set; }
        public int CourseId { get; set; }
        public string InstructorName { get; set; } = string.Empty;
        public int Seats { get; set; }

        [NotMapped]
        public bool isbought { get; set; }
    }
}