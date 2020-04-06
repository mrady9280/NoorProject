using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Student.Applicaition.Data;

namespace Student.Applicaition.Command.Student
{
    public class Delete
    {
        public class Command : IRequest
        {
            //AddParameters
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly StudentContext _context;

            public Handler(StudentContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                //Put the Business Logic here
                var student = await _context.Students.FindAsync(request.Id);
                if (student == null)
                {
                    throw new Exception("Student is not found");
                }

                _context.Students.Remove(student);

                //Add Command Logic Here
                var success = await _context.SaveChangesAsync(cancellationToken) > 0;
                return success ? Unit.Value : throw new Exception("Problem Saving the Student");
            }
        }
    }
}