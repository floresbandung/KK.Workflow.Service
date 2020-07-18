using Workflow.Shared;

namespace KK.Workflow.Service.Features.Approval
{
    public class Response
    {
        public string DisplayStatus { get; set; }
        public ActivityStatusEnum NewStatus { get; set; }
    }
}
