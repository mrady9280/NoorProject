using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Applicaition.Domain
{
    [Table("CourseStudent")]
    public class StudentCourse
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        
        public Guid StudentCourseStatusId { get; set; }
        public StudentCourseStatus CourseStatus { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
        
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}