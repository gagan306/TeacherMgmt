using System.ComponentModel.DataAnnotations;

namespace TeacherMgmt.Models
{
    public class ClassInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string ClassName { get; set; }
        
        public string ClassCode { get; set; }
        [Required]
       
        public string Shift { get; set; }
        [Required]
        
        public string Faculty { get; set; }
        [Required]
        
        public string Batch { get; set; }
        [Required]
        public TimeOnly TimeFrom { get; set; }
        [Required]
        public TimeOnly TimeTo { get; set; }
        public string ClassDays { get; set; }
       
    }
}
