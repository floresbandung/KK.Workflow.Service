using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DD.Tata.Buku.Shared.Logs;
using KK.Workflow.Service.DataContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workflow.Shared;

namespace KK.Workflow.Service.Features.Approval
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

            var nextActivityRequest = await _dataContext.ProcessActivities.FirstOrDefaultAsync(
                c => c.RowStatus == 0 && c.ProcessRequestId == request.ProcessRequestId &&
                     c.ActivityIndex == request.ActivityIndex + 1, cancellationToken);

            if (nextActivityRequest == null) throw new Exception(WorkflowMessage.INVALID_PROCESS_ACTIVITY);
            var requestStatus = await
                _dataContext.StatusRequests.FirstOrDefaultAsync(
                    c => c.RowStatus == 0 && c.RequestNumber == request.RequestNumber, cancellationToken: cancellationToken);
            if (requestStatus == null) throw new Exception(WorkflowMessage.INVALID_STATUS_REQUEST);

            requestStatus.ProcessActivityId = nextActivityRequest.Id;
            requestStatus.LastAssignDate = request.RequestDate;
            requestStatus.LastAssignTo = request.FullName;
            requestStatus.DisplayStatus =
                request.ActionName == ActionTypeEnum.Revise || request.ActionName == ActionTypeEnum.Reject
                    ? request.ActionName.ToString()
                    : nextActivityRequest.DisplayName;
            requestStatus.NewRequestStatus = request.ActionName == ActionTypeEnum.Revise ? ActivityStatusEnum.Revise :
                request.ActionName == ActionTypeEnum.Reject ? ActivityStatusEnum.Closed : nextActivityRequest.NewStatus;
            requestStatus.ModifiedBy = request.UserName;
            requestStatus.ModifiedDate = DateTime.Now;  
            requestStatus.Notes = request.Notes;

            requestStatus.Subject = nextActivityRequest.SubjectName;
            requestStatus.SlaTime = nextActivityRequest.SlaTime;
            requestStatus.SlaType = nextActivityRequest.SlaType;
            requestStatus.Subject = nextActivityRequest.SubjectName;
            requestStatus.DocumentName = request.DocumentName;
            requestStatus.DocumentNumber = request.DocumentNumber;
            requestStatus.RequestNumber = request.RequestNumber;

            if (nextActivityRequest.NewStatus == ActivityStatusEnum.Closed)
            {
                requestStatus.IsComplete = true;
                requestStatus.CompleteDate = DateTime.Now;
            }
            else
            {
                requestStatus.IsComplete = false;
                requestStatus.CompleteDate = null;
            }

            if (nextActivityRequest.NewStatus == ActivityStatusEnum.Closed)
            {
                var entity = new RequestActivity
                {
                    Notes = request.Notes, //requestParameter.Description,
                    RequestStatus = nextActivityRequest.NewStatus,
                    ProcessActivityId = nextActivityRequest.Id,
                    ActivityIndex = nextActivityRequest.ActivityIndex,
                    DisplayStatus = nextActivityRequest.DisplayName,
                    ActorCode = request.UserName,
                    ActionDate = DateTime.Now,
                    ActorName = request.FullName,
                    ActionName = request.ActionName.ToString(),
                    CreatedBy = request.UserName,
                    CreatedDate = DateTime.Now,
                    Id = Guid.NewGuid(),
                    IsComplete = true,
                    RowStatus = 0,
                    SlaTime = nextActivityRequest.SlaTime,
                    SlaType = nextActivityRequest.SlaType,
                    SubjectName = nextActivityRequest.ViewSubject.PopulateTemplate(requestStatus.RequestNumber, request.UserName, request.ActionName, request.DocumentNumber), 
                    RequestNumber = request.RequestNumber,
                    DocumentName = request.DocumentName,
                    DocumentNumber = request.DocumentNumber,
                    IpAddress = request.HostAddress
                };
                await _dataContext.RequestActivities.AddAsync(entity, cancellationToken);
            }

            var activityActors = await _dataContext.ProcessActivityActors.Where(c => c.ProcessActivityId == nextActivityRequest.Id).ToListAsync(cancellationToken);
            var actorEmail = "";
            foreach (var activityActor in activityActors)
            {
                if (activityActor.ActorCode != requestStatus.ActorCode)
                {
                    actorEmail += activityActor.ActorEmail + ";";
                    var inboxRequest = new InboxRequest
                    {
                        Id = Guid.NewGuid(),
                        CreatedDate = DateTime.Now,
                        CreatedBy = request.UserName,
                        RowStatus = 0,
                        CommitmentDate = null,
                        RequestDate = requestStatus.RequestDate,
                        RequestNumber = request.RequestNumber,
                        DisplayStatus = request.ActionName == ActionTypeEnum.Revise ||
                                        request.ActionName == ActionTypeEnum.Reject
                            ? request.ActionName.ToString()
                            : nextActivityRequest.DisplayName,
                        RequestStatus = request.ActionName == ActionTypeEnum.Revise ? ActivityStatusEnum.Revise :
                            request.ActionName == ActionTypeEnum.Reject ? ActivityStatusEnum.Closed :
                            nextActivityRequest.NewStatus,
                        ActorNameRequester = request.FullName,
                        Subject = nextActivityRequest.ViewSubject.PopulateTemplate(requestStatus.RequestNumber,
                            request.UserName, request.ActionName, request.DocumentNumber),
                        AssignDate = DateTime.Now,
                        CompleteDate =
                            nextActivityRequest.NewStatus == ActivityStatusEnum.Closed ||
                            request.ActionName == ActionTypeEnum.Reject || request.ActionName == ActionTypeEnum.Revise
                                ? DateTime.Now
                                : (DateTime?) null,
                        HasView = false,
                        IsComplete = nextActivityRequest.NewStatus == ActivityStatusEnum.Closed ||
                                     request.ActionName == ActionTypeEnum.Reject ||
                                     request.ActionName == ActionTypeEnum.Revise,
                        ActorCodeAssignees = activityActor.ActorCode,
                        ActorNameAssignees = activityActor.ActorName,
                        ActorCodeRequester = request.UserName,
                        JavascriptAction = activityActor.ActionType == ActionTypeEnum.Approval
                            ? nextActivityRequest.ApprovalJavascriptAction
                            : nextActivityRequest.ViewJavascriptAction,
                        UrlAction = nextActivityRequest.UrlAction,
                        ActionType = activityActor.ActionType == ActionTypeEnum.Approval
                            ? ActionTypeEnum.Approval
                            : ActionTypeEnum.View, //GetInboxActionType(activityActor),
                        DocumentName = request.DocumentName,
                        DocumentNumber = request.DocumentNumber,
                        StatusRequestId = requestStatus.Id
                    };
                    await _dataContext.InboxRequests.AddAsync(inboxRequest, cancellationToken);
                }
                else
                {

                    var inboxRequest = new InboxRequest
                    {
                        Id = Guid.NewGuid(),
                        CreatedDate = DateTime.Now,
                        CreatedBy = request.UserName,
                        RowStatus = 0,
                        CommitmentDate = null,
                        RequestDate = requestStatus.RequestDate,
                        RequestNumber = request.RequestNumber,
                        DisplayStatus = request.ActionName == ActionTypeEnum.Revise ||
                                        request.ActionName == ActionTypeEnum.Reject
                            ? request.ActionName.ToString()
                            : nextActivityRequest.DisplayName,
                        RequestStatus = request.ActionName == ActionTypeEnum.Revise ? ActivityStatusEnum.Revise :
                            request.ActionName == ActionTypeEnum.Reject ? ActivityStatusEnum.Closed :
                            nextActivityRequest.NewStatus,
                        ActorNameRequester = requestStatus.ActorName,
                        Subject = nextActivityRequest.ViewSubject.PopulateTemplate(requestStatus.RequestNumber,
                            request.UserName, request.ActionName, request.DocumentNumber),
                        AssignDate = DateTime.Now,
                        CompleteDate = nextActivityRequest.NewStatus == ActivityStatusEnum.Closed ||
                                       request.ActionName == ActionTypeEnum.Reject || request.ActionName == ActionTypeEnum.Revise
                            ? DateTime.Now
                            : (DateTime?)null,
                        HasView = false,
                        IsComplete = nextActivityRequest.NewStatus == ActivityStatusEnum.Closed ||
                                     request.ActionName == ActionTypeEnum.Reject ||
                                     request.ActionName == ActionTypeEnum.Revise,
                        ActorCodeAssignees = activityActor.ActorCode,
                        ActorNameAssignees = activityActor.ActorName,
                        ActorCodeRequester = requestStatus.ActorCode,
                        JavascriptAction = activityActor.ActionType == ActionTypeEnum.Approval ? nextActivityRequest.ApprovalJavascriptAction : nextActivityRequest.ViewJavascriptAction,
                        UrlAction = nextActivityRequest.UrlAction,
                        ActionType = activityActor.ActionType == ActionTypeEnum.Approval
                            ? ActionTypeEnum.Approval
                            : ActionTypeEnum.View,
                        DocumentName = request.DocumentName,
                        DocumentNumber = request.DocumentNumber,
                        StatusRequestId = requestStatus.Id,
                    };
                    await _dataContext.InboxRequests.AddAsync(inboxRequest, cancellationToken);
                }

                // for viewer
                if (activityActor.ActionType != ActionTypeEnum.Approval) continue;

                requestStatus.LastAssignDate = DateTime.Now;
                requestStatus.LastAssignTo = activityActor.ActorCode;
                requestStatus.ActorCode = activityActor.ActorCode;
                requestStatus.ActorName = activityActor.ActorName;

                var newActivity = new RequestActivity
                {
                    Notes = "",//requestParameter.Description,
                    RequestStatus = nextActivityRequest.NewStatus,
                    ProcessActivityId = nextActivityRequest.Id,
                    ActivityIndex = nextActivityRequest.ActivityIndex,
                    DisplayStatus = nextActivityRequest.DisplayName,
                    ActorCode = activityActor.ActorCode,
                    ActionDate = null,
                    ActorName = activityActor.ActorName,
                    ActionName = null,
                    CreatedBy = request.UserName,
                    CreatedDate = DateTime.Now,
                    Id = Guid.NewGuid(),
                    IsComplete = false,
                    RowStatus = 0,
                    SlaTime = nextActivityRequest.SlaTime,
                    SlaType = nextActivityRequest.SlaType,
                    SubjectName = nextActivityRequest.ViewSubject.PopulateTemplate(requestStatus.RequestNumber,
                        request.UserName, request.ActionName, request.DocumentNumber),
                    RequestNumber = request.RequestNumber,
                    DocumentName = request.DocumentName,
                    DocumentNumber = request.DocumentNumber,
                    IpAddress = request.HostAddress,
                    //UserHostname = requestParameter.User.HostName

                };
                await _dataContext.RequestActivities.AddAsync(newActivity, cancellationToken);
            }

            var emailTask = new EmailTask
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                CreatedBy = request.UserName,
                RowStatus = 0,
                ModifiedBy = "",
                ModifiedDate = null,
                EmailBody = "",
                EmailCc = "",
                EmailFrom = "",
                EmailSubject = nextActivityRequest.SubjectName,
                EmailTo = actorEmail,
                SourceId = nextActivityRequest.Id,
                TaskFrom = nextActivityRequest.SubjectName,
            };

            await _dataContext.EmailTasks.AddAsync(emailTask, cancellationToken);
            /*DisplayStatusNextActivity = nextActivityRequest.DisplayName;
            NextActivityHasChanged(new ProcessEventArgs()
            {
                DisplayStatus = nextActivityRequest.DisplayName,
                NewStatus = nextActivityRequest.NewStatus,
                OldStatus = "",
                NoAction = false
            });*/
            return new Response
            {
                DisplayStatus = nextActivityRequest.DisplayName,
                NewStatus = nextActivityRequest.NewStatus
            };
        }
    }
}
