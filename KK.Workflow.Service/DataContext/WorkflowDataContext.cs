using System;
using DD.TataBuku.Shared.Fault;
using Microsoft.EntityFrameworkCore;

namespace KK.Workflow.Service.DataContext
{
    public class WorkflowDataContext : DbContext
    {
        public WorkflowDataContext()
        {

        }

        public WorkflowDataContext(DbContextOptions<WorkflowDataContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("workflowConnectionString") ?? throw new InvalidOperationException(StaticMessage.INVALID_CONNECTION_STRING));
            }
        }

        public virtual DbSet<WorkflowRegistry> WorkflowRegistries { get; set; }
        public virtual DbSet<TemplateProcessActivity> TemplateProcessActivities { get; set; }
        public virtual DbSet<TemplateProcessRequest> TemplateProcessRequests { get; set; }
        public virtual DbSet<TemplateProcessActivityActor> TemplateProcessActivityActors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkflowRegistry>().HasIndex(transaction => transaction.WorkflowCode).IsUnique();
            modelBuilder.Entity<TemplateProcessRequest>().HasIndex(x => new
            {
                x.CompanyCode,
                x.ModuleCode
            }).IsUnique();

            modelBuilder.Entity<TemplateProcessRequest>()
                .HasOne(x => x.WorkflowRegistry)
                .WithMany(x => x.TemplateProcessRequests)
                .HasForeignKey(x => x.WorkflowId);

            modelBuilder.Entity<TemplateProcessActivity>()
                .HasOne(x => x.TemplateProcessRequest)
                .WithMany(x => x.TemplateProcessActivities)
                .HasForeignKey(x => x.ProcessRequestId);

            modelBuilder.Entity<TemplateProcessActivityActor>()
                .HasOne(x => x.TemplateProcessActivity)
                .WithMany(x => x.TemplateProcessActivityActors)
                .HasForeignKey(x => x.ProcessActivityId);

            modelBuilder.Entity<ProcessRequest>()
                .HasOne(x => x.WorkflowRegistry)
                .WithMany(x => x.ProcessRequests)
                .HasForeignKey(x => x.WorkflowId);

            modelBuilder.Entity<ProcessActivity>()
                .HasOne(x => x.ProcessRequest)
                .WithMany(x => x.ProcessActivities)
                .HasForeignKey(x => x.ProcessRequestId);

            modelBuilder.Entity<ProcessActivityActor>()
                .HasOne(x => x.ProcessActivity)
                .WithMany(x => x.ProcessActivityActors)
                .HasForeignKey(x => x.ProcessActivityId);

            modelBuilder.Entity<StatusRequest>()
                .HasOne(x => x.ProcessActivity)
                .WithMany(x => x.StatusRequests)
                .HasForeignKey(x => x.ProcessActivityId);

            modelBuilder.Entity<InboxRequest>()
                .HasOne(x => x.StatusRequest)
                .WithMany(x => x.InboxRequests)
                .HasForeignKey(x => x.StatusRequestId);
        }
    }
}
