using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Student.Applicaition.Data;

namespace Student.Applicaition.Command.Course
{
    public class List
    {
        public class CourseModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public bool IsActive { get; set; }
        }

        public class Query : IRequest<List<CourseModel>>
        {
            //AddParameters
        }

        public class Handler : IRequestHandler<Query, List<CourseModel>>
        {
            private readonly StudentContext _context;
            private readonly IMapper _mapper;

            public Handler(StudentContext context,IMapper mapper)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }
            public async Task<List<CourseModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var courses = await _context.Courses.Where(e => e.IsActive).ToListAsync(cancellationToken);
                //Add Business Logic Here
                return _mapper.Map<List<CourseModel>>(courses);
            }
        }
    }
}