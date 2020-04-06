using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Applicaition.Domain
{
    [Table("StudentCourseStatus")]
    public class StudentCourseStatus
    {
        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
        
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}