using System.Threading.Tasks;
using KK.Workflow.Service.DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KK.Workflow.Service.Infrastructures
{
    public static class Extensions
    {
        public static async Task<IApplicationBuilder> MigrateDatabase(this IApplicationBuilder builder)
        {
            using var serviceScope = builder.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
            await using var context = serviceScope.ServiceProvider.GetService<WorkflowDataContext>();
            await context.Database.MigrateAsync();
            return builder;
        }
    }
}
