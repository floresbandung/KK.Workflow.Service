using System;
using MediatR;
using Workflow.Shared;

namespace KK.Workflow.Service.Features.Submit
{
    public class Request : BaseRequest, IRequest<Response>
    {
        public ActionTypeEnum ActionName { get; set; }
        public string UserName { get; set; }

        public DateTime RequestDate { get; set; }
        public string Notes { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentName { get; set; }
        public string ModuleName { get; set; }
        public string UserFullName { get; set; }
        public string IpAddress { get; set; }
    }
}
