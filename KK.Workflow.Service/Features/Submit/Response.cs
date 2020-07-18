using Workflow.Shared;

namespace KK.Workflow.Service.Features.Submit
{
    public class Response
    {
        public string RequestNumber { get; set; }
        public ActivityStatusEnum Status { get; set; }
        public string DisplayStatus { get; set; }
    }
}
