﻿using System.ComponentModel.DataAnnotations;

namespace TeacherMgmt.Models
{
    public class Teacher
    {
        [Key]
        public Guid TeacherId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string Subject { get; set; } 
        [Required]
        [MaxLength(150)]
        public string SubField{ get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required]
        [Phone]
        [MaxLength(10)]
        public string Phone { get; set; }

        [Required]
        public TimeOnly TimeFrom { get; set; }

        [Required]
        public TimeOnly TimeTo { get; set; }

        [Required]
        [MaxLength(500)]
        public string Message { get; set; }  

       
        [MaxLength(100)]
        public string PreferredContact { get; set; }

        [Required]
        public string Department { get; set; }
        [Required]
        public string Faculty { get; set; }

    }
}
