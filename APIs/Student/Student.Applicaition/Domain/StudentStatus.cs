using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Applicaition.Domain
{
    [Table("StudentStatus")]
    public class StudentStatus
    {
        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string Description { get; set; }

        public ICollection<Student> Students { get; set; }
        
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}