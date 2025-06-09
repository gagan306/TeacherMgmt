using System.ComponentModel.DataAnnotations;

namespace TeacherMgmt.Models
{
    public class ClassInfo
    {
        [Key]
        public int ClassId { get; set; }
        [Required]
        [MaxLength(100)]
        
        
        public string ClassName { get; set; }
        [Required]
       
        public string Shift { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public int BreakDuration { get; set; }
        [Required]
        public string Faculty { get; set; }
        [Required]
        
        public string Batch { get; set; }
        [Required]
        public string TimeFrom { get; set; }
        [Required]
        public  string TimeTo { get; set; }
       

    }
}
