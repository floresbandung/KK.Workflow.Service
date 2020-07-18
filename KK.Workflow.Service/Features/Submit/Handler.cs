using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace KK.Workflow.Service.Features.Submit
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Handler(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var copyResponse = await _mediator.Send(new CopyTemplate.Request
            {
                ModuleName = request.ModuleName,
                UserName = request.UserName,
                UseTransaction = false
            }, cancellationToken);

            var g = await _mediator.Send(new NewProcess.Request
            {
                ActionName = request.ActionName,
                ProcessRequestId = copyResponse.ProcessRequestId,
                UseTransaction = false,
                ReferenceKey = request.ReferenceKey,
                RequestNumber = copyResponse.RequestNumber,
                DocumentNumber = request.DocumentNumber,
                Notes = request.Notes,
                DocumentName = request.DocumentName,
                FullName = request.UserFullName,
                HostAddress = request.IpAddress,
                RequestDate = request.RequestDate,
                UserName = request.UserName,
                IpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString()
        }, cancellationToken);

            return  new Response();
        }
    }
}
