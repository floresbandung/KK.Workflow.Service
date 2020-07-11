using System;
using DD.Tata.Buku.Shared.Infrastructures;
using DD.TataBuku.Shared.Fault;
using KK.Workflow.Service.DataContext;
using KK.Workflow.Service.Infrastructures;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KK.Workflow.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<WorkflowDataContext>(x =>
                x.UseNpgsql(Environment.GetEnvironmentVariable("workflowConnectionString") ??
                            throw new InvalidOperationException(StaticMessage.INVALID_CONNECTION_STRING)));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionDecorator<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationDecorator<,>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.MigrateDatabase().Wait();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
