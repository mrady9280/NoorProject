using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Applicaition.Domain
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string SecondName { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string ThirdName { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string LastName { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string NickName { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string Address { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string City { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Country { get; set; }
        [Column(TypeName = "varbinary(max)")]
        public byte[] Image { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Notes { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Mobile { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Phone { get; set; }
        
        public Guid  StatusId { get; set; }
        public StudentStatus StudentStatus { get; set; }
        public Guid GradeId { get; set; }
        public Grade StudentGrade { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}