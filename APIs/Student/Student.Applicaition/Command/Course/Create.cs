using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Student.Applicaition.Data;

namespace Student.Applicaition.Command.Course
{
    public class Create
    {
        public class Command : IRequest
        {
            //AddParameters
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly StudentContext _context;
            private readonly IMapper _mapper;

            public Handler(StudentContext context,IMapper mapper)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                //Put the Business Logic here
                var course = _mapper.Map<Domain.Course>(request);
                course.CreatedBy = "Mohamed Rady";
                course.DateCreated = DateTime.Now;
                course.IsActive = true;
                _context.Courses.Add(course);
                var success = await _context.SaveChangesAsync(cancellationToken) > 0;
                return success ? Unit.Value : throw new Exception("Problem Saving the Data");

            }
        }
    }
}