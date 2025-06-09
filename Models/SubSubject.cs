using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeacherMgmt.Models
{
    public class SubSubject
    {
        [Key]
        public int SubSubjectId { get; set; }

        [Required]
        public string SubSubjectName { get; set; }

        public string SubClassType { get; set; }

        [Required]
        public string SubjectCode { get; set; }

        [ForeignKey("SubjectCode")]
        public Subjectinfo Subject { get; set; }
    }
}
