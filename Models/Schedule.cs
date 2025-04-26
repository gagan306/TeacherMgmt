using System.ComponentModel.DataAnnotations;

namespace TeacherMgmt.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        [Required]
        public Guid TeacherId { get; set; }
        [Required]
        [MaxLength(100)]
        public string TeacherName { get; set; }
        [Required]
        [MaxLength(150)]
        public string Subject { get; set; }
        [Required]
        public TimeOnly TimeFrom { get; set; }
        [Required]
        public TimeOnly TimeTo { get; set; }
        [Required]
        public string Batch { get; set; }
        [Required]
        public string Sift { get; set; }
        [Required]
        public string Faculty { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
