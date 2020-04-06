using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Student.Applicaition.Command.Course;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController: ControllerBase
    {
        private readonly ILogger<CourseController> _logger;
        private readonly IMediator _mediator;

        public CourseController(ILogger<CourseController> logger,IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet()]
        public async Task<ActionResult<List<List.CourseModel>>> List()
        {
            return Ok( await _mediator.Send(new List.Query()));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Details.CourseModel>> Details(Guid id)
        {
            return Ok( await _mediator.Send(new Details.Query(){Id = id}));
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create([FromBody] Create.Command course)
        {
            return Ok(await _mediator.Send(course));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(Guid id,[FromBody] Update.Command course)
        {
            course.Id = id;
            return Ok(await _mediator.Send(course));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return Ok(await _mediator.Send(new Delete.Command(){Id = id}));
        }
    }
}