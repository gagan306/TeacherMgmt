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
    public class SubjectInfoDto
    {
        public int? SubjectId { get; set; } // Nullable for create (no ID yet), set for update

        public string SubjectCode { get; set; }

        public string SubjectName { get; set; }

        public string CreditHours { get; set; }

        public string Department { get; set; }

        public string Batch { get; set; }

        public string ClassType { get; set; }

        public string Faculty { get; set; }

        // Optional: If you want to allow input about subsubjects presence and count, else omit
        public bool HasSubSubjects { get; set; } = false;

        public int SubSubjectCount { get; set; } = 0;
    }

}
