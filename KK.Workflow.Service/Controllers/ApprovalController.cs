using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KK.Workflow.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApprovalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("new")]
        [HttpPost]
        public async Task<IActionResult> Submit([FromBody] Features.NewProcess.Request request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}