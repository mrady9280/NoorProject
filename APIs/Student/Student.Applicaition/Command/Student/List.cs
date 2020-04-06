using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Student.Applicaition.Data;

namespace Student.Applicaition.Command.Student
{
    public class List
    {
        public class StudentModel
        {
            public Guid Id { get; set; }
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public string ThirdName { get; set; }
            public string LastName { get; set; }
            public string NickName { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public byte[] Image { get; set; }
            public string Notes { get; set; }
            public string Mobile { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
        }
        public class Query : IRequest<List<StudentModel>>
        {
            //AddParameters
        }

        public class Handler : IRequestHandler<Query, List<StudentModel>>
        {
            private readonly StudentContext _context;
            private readonly IMapper _mapper;

            public Handler(StudentContext context,IMapper mapper)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }
            public async Task<List<StudentModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var students = await _context.Students.Where(e => e.IsActive).ToListAsync(cancellationToken);
                //Add Business Logic Here
                var result = _mapper.Map<List<StudentModel>>(students);
                return result;
            }
        }
    }
}