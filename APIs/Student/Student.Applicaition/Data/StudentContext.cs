using Microsoft.EntityFrameworkCore;
using Student.Applicaition.Domain;

namespace Student.Applicaition.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Domain.Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<StudentStatus> StudentStatuses { get; set; }
        public DbSet<StudentCourseStatus> StudentCourseStatuses { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Student>().HasOne<Grade>(e => e.StudentGrade).WithMany(g => g.Students)
                .HasForeignKey(s => s.GradeId);
            modelBuilder.Entity<Domain.Student>().HasOne<StudentStatus>(e => e.StudentStatus).WithMany(s => s.Students)
                .HasForeignKey(s => s.StatusId);
            modelBuilder.Entity<Domain.StudentCourse>().HasOne<Domain.Student>(e => e.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(s => s.StudentId);
            modelBuilder.Entity<Domain.StudentCourse>().HasOne<Domain.Course>(e => e.Course)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(s => s.CourseId);
            modelBuilder.Entity<Domain.StudentCourse>().HasOne<StudentCourseStatus>(e => e.CourseStatus)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(s => s.StudentCourseStatusId);



            base.OnModelCreating(modelBuilder);
        }
    }
}