using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DD.Tata.Buku.Shared.Logs;
using KK.Workflow.Service.DataContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Omu.ValueInjecter;
using Workflow.Shared;

namespace KK.Workflow.Service.Features.CopyTemplate
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
            var templateProcessRequest = await _dataContext.TemplateProcessRequests.FirstOrDefaultAsync(
                a => a.ModuleName.ToUpper().Equals(request.ModuleName.ToUpper()) && a.StartActive <= DateTime.Now &&
                     a.EndActive >= DateTime.Now, cancellationToken: cancellationToken);

            if (templateProcessRequest == null)
                throw new Exception(WorkflowMessage.INVALID_MODULE);

            var templateProcessActivities =
                _dataContext.TemplateProcessActivities.Where(c => c.ProcessRequestId.Equals(templateProcessRequest.Id)).ToList();

            if (templateProcessActivities.Count == 0)
                throw new Exception(WorkflowMessage.INVALID_PROCESS_ACTIVITY);

            var templateProcessActivityActors = await _dataContext.TemplateProcessActivityActors.Where(x =>
                templateProcessActivities.Select(c => c.Id).Contains(x.ProcessActivityId)).ToListAsync(cancellationToken: cancellationToken);

            _apiLogger.Debug("Inject process request");
            var newProcessRequest = new ProcessRequest();
            newProcessRequest.InjectFrom(templateProcessRequest);
            newProcessRequest.Id = Guid.NewGuid();
            newProcessRequest.CreatedBy = request.UserName;
            newProcessRequest.CreatedDate = DateTime.UtcNow;
            newProcessRequest.ModifiedBy = null;
            newProcessRequest.ModifiedDate = null;

            _apiLogger.Debug("Inject process activities");
            var newProcessActivities = new List<ProcessActivity>();
            newProcessActivities.AddRange(
                templateProcessActivities.Select(source => (ProcessActivity)new ProcessActivity().InjectFrom(source)));

            _apiLogger.Debug("Inject process activity actors");
            var newProcessActivityActors = new List<ProcessActivityActor>();
            newProcessActivityActors.AddRange(
                templateProcessActivityActors.Select(source => (ProcessActivityActor)new ProcessActivityActor().InjectFrom(source)));

            var requestNumber = await _numbering.NewRequestNumber();
            newProcessRequest.RequestNumber = requestNumber;
            await _dataContext.ProcessRequests.AddAsync(newProcessRequest, cancellationToken);

            foreach (var activity in newProcessActivities)
            {
                var newid = Guid.NewGuid();
                var activity1 = activity;
                foreach (var actor in newProcessActivityActors.Where(s => s.ProcessActivityId == activity1.Id))
                {
                    actor.Id = Guid.NewGuid();
                    actor.ProcessActivityId = newid;
                    actor.CreatedBy = request.UserName;
                    actor.CreatedDate = DateTime.UtcNow;
                    actor.ModifiedBy = null;
                    actor.ModifiedDate = null;
                }
                activity.Id = newid;
                activity.ProcessRequestId = newProcessRequest.Id;
                activity.CreatedBy = request.UserName;
                activity.CreatedDate = DateTime.UtcNow;
                activity.ModifiedBy = null;
                activity.ModifiedDate = null;
            }

            await _dataContext.ProcessActivities.AddRangeAsync(newProcessActivities, cancellationToken);
            await _dataContext.ProcessActivityActors.AddRangeAsync(newProcessActivityActors, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return new Response
            {
                RequestNumber = requestNumber,
                ProcessRequestId = newProcessRequest.Id
            };
        }
    }
}
