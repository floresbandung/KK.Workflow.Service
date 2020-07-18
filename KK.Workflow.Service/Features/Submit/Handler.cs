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

            var newProcessResponse = await _mediator.Send(new NewProcess.Request
            {
                ActionName = request.ActionName,
                ProcessRequestId = copyResponse.ProcessRequestId,
                UseTransaction = false,
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

            var response = await _mediator.Send(new Approval.Request
            {
                ActivityIndex = newProcessResponse.ActivityIndex,
                ProcessRequestId = copyResponse.ProcessRequestId,
                RequestDate = request.RequestDate,
                FullName = request.UserFullName,
                UserName = request.UserName,
                RequestNumber = copyResponse.RequestNumber,
                DocumentNumber = request.DocumentNumber,
                DocumentName = request.DocumentName,
                HostAddress = request.IpAddress,
                ActionName = request.ActionName,
                Notes = request.Notes,
                UseTransaction = false
            }, cancellationToken);
            

            return new Response
            {
                RequestNumber = copyResponse.RequestNumber,
                Status = response.NewStatus,
                DisplayStatus = response.DisplayStatus
            };
        }
    }
}
