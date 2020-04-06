using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Student.Applicaition.Data;

namespace Student.Applicaition.Command.Course
{
    public class Details
    {
        public class CourseModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public bool IsActive { get; set; }
        }
        public class Query : IRequest<CourseModel>
        {
            //AddParameters
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, CourseModel>
        {
            private readonly StudentContext _context;
            private readonly IMapper _mapper;

            public Handler(StudentContext context,IMapper mapper)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<CourseModel> Handle(Query request, CancellationToken cancellationToken)
            {
                //Add Business Logic Here
                var course = await _context.Courses.FindAsync(request.Id);
                if(course == null) throw new Exception("Course Is Not Found");
                return _mapper.Map<CourseModel>(course);
            }
        }
    }
}