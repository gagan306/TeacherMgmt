using System.ComponentModel.DataAnnotations;

namespace TeacherMgmt.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(150)]
        public string Subject { get; set; }
        [MaxLength(500)]
        public string Message { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Faculty { get; set; }
        [Required]
        public string Available { get; set; } = "absent";
    }
}
