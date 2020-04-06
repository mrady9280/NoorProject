using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Applicaition.Domain
{
    [Table("Course")]
    public class Course
    {
        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; }
        
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}