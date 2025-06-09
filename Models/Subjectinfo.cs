using System.ComponentModel.DataAnnotations;

namespace TeacherMgmt.Models
{
    public class Subjectinfo
    {
        [Key]
        public int SubjectId { get; set; }

        [Required]
        public string SubjectCode { get; set; }

        [Required]
        public string SubjectName { get; set; }

        [Required]
        public string CreditHours { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Batch { get; set; }

        [Required]
        public string ClassType { get; set; }

        [Required]
        public string Faculty { get; set; }

        // ✅ New field: indicates whether subsubjects exist
        public bool HasSubSubjects { get; set; } = false;

        // ✅ New field: number of subsubjects
        public int SubSubjectCount { get; set; } = 0;

        // Optional navigation property
        public ICollection<SubSubject> SubSubjects { get; set; }
    }
}
