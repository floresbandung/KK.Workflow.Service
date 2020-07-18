using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DD.Tata.Buku.Shared.Logs;
using DD.TataBuku.Shared.Fault;
using KK.Workflow.Service.DataContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workflow.Shared;

namespace KK.Workflow.Service.Features.NewProcess
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IApiLogger _apiLogger;
        private readonly WorkflowDataContext _dataContext;
        private readonly NumberingHelper _numbering;

        public Handler(IApiLogger apiLogger, WorkflowDataContext dataContext, NumberingHelper numbering)
        {
            _apiLogger = apiLogger;
            _dataContext = dataContext;
            _numbering = numbering;
        }
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            if (request.ActionName != ActionTypeEnum.New)
                throw new Exception(StaticMessage.INVALID_REQUEST_TYPE);

            var now = DateTime.Now;

            var processActivity =
                await _dataContext.ProcessActivities.Where(a => a.ProcessRequestId == request.ProcessRequestId)
                    .OrderBy(c => c.ActivityIndex)
                    .FirstOrDefaultAsync(cancellationToken);

            if (processActivity == null) throw new Exception(StaticMessage.PROCESS_ACTIVITY_NOT_FOUND);
            if (processActivity.ActivityIndex != 1) throw new Exception(StaticMessage.INVALID_PROCESS_ACTIVITY_INDEX);

            var processActivityActors = await _dataContext.ProcessActivityActors
                .Where(c => c.ProcessActivityId == processActivity.Id)
                .ToListAsync(cancellationToken: cancellationToken);

            var processActivityActor = processActivityActors.FirstOrDefault(c => c.ActorCode == request.UserName && c.ActionType == ActionTypeEnum.Approval);
            if (processActivityActor == null)
                throw new Exception(StaticMessage.INVALID_USER_RIGHT_APPROVAL);

            var statusRequest = new StatusRequest
            {
                ProcessActivityId = processActivity.Id,
                Id = Guid.NewGuid(),
                SlaTime = processActivity.SlaTime,
                CreatedDate = now,
                NewRequestStatus = processActivity.NewStatus,
                CreatedBy = request.UserName,
                RowStatus = 0,
                SlaType = processActivity.SlaType,
                CommitmentDate = null,
                LastAssignDate = request.RequestDate,
                LastAssignTo = request.FullName,
                Notes = request.Notes,
                RequestDate = request.RequestDate,
                RequestNumber = request.RequestNumber,
                DisplayStatus = processActivity.DisplayName,
                ActorCode = request.UserName,
                ActorName = request.FullName,
                Subject = processActivity.SubjectName.PopulateTemplate(request.RequestNumber, request.UserName, request.ActionName, request.DocumentNumber),
                ReferenceKey = request.ReferenceKey,
                IsComplete = false,
                DocumentName = request.DocumentName,
                DocumentNumber = request.DocumentNumber
            };

            await _dataContext.StatusRequests.AddAsync(statusRequest, cancellationToken);

            var activity = new RequestActivity
            {
                Notes = request.Notes,
                RequestStatus = processActivity.NewStatus,
                ProcessActivityId = processActivity.Id,
                ActivityIndex = processActivity.ActivityIndex,
                DisplayStatus = processActivity.DisplayName,
                ActorCode = request.UserName,
                ActionDate = request.RequestDate,
                ActorName = request.FullName,
                ActionName = processActivity.NewStatus.ToString(),
                CreatedBy = request.UserName,
                CreatedDate = now,
                Id = Guid.NewGuid(),
                IsComplete = true,
                RowStatus = 0,
                SlaTime = processActivity.SlaTime,
                SlaType = processActivity.SlaType,
                SubjectName = processActivity.SubjectName.PopulateTemplate(request.RequestNumber, request.UserName, request.ActionName, request.DocumentNumber),
                ReferenceKey = request.ReferenceKey,
                RequestNumber = request.RequestNumber,
                DocumentName = request.DocumentName,
                DocumentNumber = request.DocumentNumber,
                IpAddress = request.HostAddress
            };

            await _dataContext.RequestActivities.AddAsync(activity, cancellationToken);

            var emailTo = "";
            foreach (var activityActor in processActivityActors.Where(activityActor => activityActor.ActorCode != request.UserName))
            {
                emailTo += activityActor.ActorEmail + ";";
                var inbox = new InboxRequest
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = now,
                    CreatedBy = request.UserName,
                    RowStatus = 0,
                    CommitmentDate = null,
                    RequestDate = request.RequestDate,
                    RequestNumber = request.RequestNumber,
                    RequestStatus = processActivity.NewStatus,
                    ActorNameRequester = request.FullName,
                    Subject = processActivity.ViewSubject.PopulateTemplate(statusRequest.RequestNumber, statusRequest.ActorName, request.ActionName, request.DocumentNumber), 
                    //CreatePreSubject(processActivity, requestStatu, activityActor),
                    AssignDate = now,
                    CompleteDate = now,
                    HasView = false,
                    IsComplete = true,
                    ActorCodeAssignees = activityActor.ActorCode,
                    ActorNameAssignees = activityActor.ActorName,
                    ActorCodeRequester = request.UserName,
                    JavascriptAction = processActivity.ViewJavascriptAction,
                    UrlAction = processActivity.UrlAction,
                    DisplayStatus = processActivity.DisplayName,
                    ReferenceKey = request.ReferenceKey,
                    ActionType = ActionTypeEnum.View,
                    DocumentName = request.DocumentName,
                    DocumentNumber = request.DocumentNumber,

                };
                await _dataContext.InboxRequests.AddAsync(inbox, cancellationToken);
            }

            var emailTask = new EmailTask
            {
                Id = Guid.NewGuid(),
                CreatedDate = now,
                CreatedBy = request.UserName,
                RowStatus = 0,
                ModifiedBy = "",
                ModifiedDate = DateTime.Now,
                EmailBody = "",
                EmailCc = "",
                EmailFrom = "",
                EmailSubject = "",//CreatePreSubject(processActivity, statusRequest, processActivityActor, requestParameter),
                EmailTo = emailTo,
                SourceId = processActivity.Id,
                TaskFrom = "NEW PROCESS",
            };

            await _dataContext.EmailTasks.AddAsync(emailTask, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);
            /*requestParameter.RequestNumber = requestNumber;

            NextActivityHasChangedEvent +=
                delegate (object o, ProcessEventArgs args)
                {
                    OnStatusChanged(args);
                };

            ApprovalProcess(processActivity, requestParameter);*/

            return new Response();
        }
    }
}
