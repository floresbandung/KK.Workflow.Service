using MediatR;

namespace KK.Workflow.Service.Features.CopyTemplate
{
    public class Request : BaseRequest, IRequest<Response>
    {
        public string UserName { get; set; }
        public string ModuleName { get; set; }
    }
}
