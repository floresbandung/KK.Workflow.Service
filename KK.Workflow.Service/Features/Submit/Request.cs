using System;
using MediatR;
using Workflow.Shared;

namespace KK.Workflow.Service.Features.Submit
{
    public class Request : BaseRequest, IRequest<Response>
    {
        /// <summary>
        /// object id 
        /// </summary>
        public string TicketId { get; set; }
        public string RequestStatus { get; set; }
        public ActionTypeEnum ActionName { get; set; }
        public string UserName { get; set; }

        public DateTime RequestDate { get; set; }
        public DateTime AssignDate { get; set; }
        /// <summary>
        /// diisi untuk notes
        /// </summary>
        public string Notes { get; set; }
        public string RequestNumber { get; set; }
        /// <summary>
        /// pada saat submit tidak digunakan
        /// </summary>
        public Guid CompanyId { get; set; }
        /// <summary>
        /// pada saat submit tidak digunakan
        /// </summary>
        public Guid ModuleId { get; set; }
        public string WorkflowProcessName { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentName { get; set; }
        public string ModuleName { get; set; }
        public double Value { get; set; }
        public string ReferenceKey { get; set; }
        public string UserFullName { get; set; }
        public string IpAddress { get; set; }
    }
}
