using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using KK.Workflow.Service.DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace KK.Workflow.Service.Infrastructures
{
    public static class Extensions
    {
        public static async Task MigrateDatabase(this IApplicationBuilder builder)
        {
            using var serviceScope = builder.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
            await using var context = serviceScope.ServiceProvider.GetService<WorkflowDataContext>();
            await context.Database.MigrateAsync();
        }

        public static async Task InitData(this IApplicationBuilder builder)
        {
            using var serviceScope = builder.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
            await using var context = serviceScope.ServiceProvider.GetService<WorkflowDataContext>();
            await InitWorkflowRegistry(context);
            await InitTemplateProcessRequest(context);
            await InitTemplateProcessActivity(context);
            await InitTemplateProcessActivityActor(context);
        }

        private static async Task InitTemplateProcessActivityActor(WorkflowDataContext context)
        {
            if (!File.Exists(@"Data/template-process-activity-actor.json")) return;
            var source = await File.ReadAllTextAsync(@"Data/template-process-activity-actor.json");
            var templateProcessActivityActors = JsonConvert.DeserializeObject<List<TemplateProcessActivityActor>>(source);
            foreach (var templateProcessActivityActor in templateProcessActivityActors)
            {
                var entity = await context.TemplateProcessActivityActors.FirstOrDefaultAsync(x => x.Id == templateProcessActivityActor.Id);
                if (entity != null) continue;
                await context.TemplateProcessActivityActors.AddAsync(templateProcessActivityActor);
            }

            await context.SaveChangesAsync();
        }

        private static async Task InitTemplateProcessActivity(WorkflowDataContext context)
        {
            if (!File.Exists(@"Data/template-process-activity.json")) return;
            var source = await File.ReadAllTextAsync(@"Data/template-process-activity.json");
            var templateProcessActivities = JsonConvert.DeserializeObject<List<TemplateProcessActivity>>(source);
            foreach (var templateProcessActivity in templateProcessActivities)
            {
                var entity = await context.TemplateProcessActivities.FirstOrDefaultAsync(x => x.Id == templateProcessActivity.Id);
                if (entity != null) continue;
                await context.TemplateProcessActivities.AddAsync(templateProcessActivity);
            }

            await context.SaveChangesAsync();
        }

        private static async Task InitTemplateProcessRequest(WorkflowDataContext context)
        {
            if (!File.Exists(@"Data/template-process-request.json")) return;
            var source = await File.ReadAllTextAsync(@"Data/template-process-request.json");
            var templateProcessRequests = JsonConvert.DeserializeObject<List<TemplateProcessRequest>>(source);
            foreach (var templateProcessRequest in templateProcessRequests)
            {
                var entity = await context.TemplateProcessRequests.FirstOrDefaultAsync(x => x.Id == templateProcessRequest.Id);
                if (entity != null) continue;
                await context.TemplateProcessRequests.AddAsync(templateProcessRequest);
            }

            await context.SaveChangesAsync();
        }

        private static async Task InitWorkflowRegistry(WorkflowDataContext context)
        {
            if (!File.Exists(@"Data/workflow-registry.json"))return;
            var source = await File.ReadAllTextAsync(@"Data/workflow-registry.json");
            var workflowRegistries = JsonConvert.DeserializeObject<List<WorkflowRegistry>>(source);
            foreach (var workflowRegistry in workflowRegistries)
            {
                var entity = await context.WorkflowRegistries.FirstOrDefaultAsync(x => x.Id == workflowRegistry.Id);
                if (entity != null) continue;
                await context.WorkflowRegistries.AddAsync(workflowRegistry);
            }

            await context.SaveChangesAsync();
        }
    }
}
