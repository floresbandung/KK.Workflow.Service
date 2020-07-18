using System;
using MediatR;
using Workflow.Shared;

namespace KK.Workflow.Service.Features.Approval
{
    public class Request : BaseRequest, IRequest<Response>
    {
        public Guid ProcessRequestId { get; set; }
        public int ActivityIndex { get; set; }
        public DateTime RequestDate { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string DocumentName { get; set; }
        public string DocumentNumber { get; set; }
        public string RequestNumber { get; set; }
        public string HostAddress { get; set; }
        public ActionTypeEnum ActionName { get; set; }
        public string Notes { get; set; }
    }
}
