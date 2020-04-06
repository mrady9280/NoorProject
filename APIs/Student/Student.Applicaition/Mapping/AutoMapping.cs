using AutoMapper;
using Student.Applicaition.Command;
using Student.Applicaition.Command.Student;
using Student.Applicaition.Domain;

namespace Student.Applicaition.Mapping
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<Student.Applicaition.Command.Course.Create.Command, Course>();
            CreateMap<Student.Applicaition.Command.Course.Update.Command, Course>();
            CreateMap<Course, Student.Applicaition.Command.Course.List.CourseModel>();
            CreateMap<Course, Student.Applicaition.Command.Course.Details.CourseModel>();
            CreateMap<Student.Applicaition.Command.Student.Create.Command, Domain.Student>();
            CreateMap<Student.Applicaition.Command.Student.Update.Command, Domain.Student>();
            CreateMap<Domain.Student, List.StudentModel>();
            CreateMap<Domain.Student, Details.StudentModel>();
        }
    }
}