﻿// <auto-generated />
using System;
using KK.Workflow.Service.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KK.Workflow.Service.Migrations
{
    [DbContext(typeof(WorkflowDataContext))]
    partial class WorkflowDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("KK.Workflow.Service.DataContext.InboxRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ActionType")
                        .HasColumnType("integer");

                    b.Property<string>("ActorCodeAssignees")
                        .IsRequired()
                        .HasColumnType("character varying(24)")
                        .HasMaxLength(24);

                    b.Property<string>("ActorCodeRequester")
                        .IsRequired()
                        .HasColumnType("character varying(24)")
                        .HasMaxLength(24);

                    b.Property<string>("ActorNameAssignees")
                        .IsRequired()
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<string>("ActorNameRequester")
                        .IsRequired()
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<DateTime>("AssignDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("CommitmentDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("CompleteDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("character varying(24)")
                        .HasMaxLength(24);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DisplayStatus")
                        .IsRequired()
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<string>("DocumentName")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("DocumentNumber")
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<bool>("HasView")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("boolean");

                    b.Property<string>("JavascriptAction")
                        .HasColumnType("character varying(1024)")
                        .HasMaxLength(1024);

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("character varying(24)")
                        .HasMaxLength(24);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ReferenceKey")
                        .IsRequired()
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RequestNumber")
                        .IsRequired()
                        .HasColumnType("character varying(32)")
                        .HasMaxLength(32);

                    b.Property<int>("RequestStatus")
                        .HasColumnType("integer");

                    b.Property<byte>("RowStatus")
                        .HasColumnType("smallint");

                    b.Property<Guid>("StatusRequestId")
                        .HasColumnType("uuid");

                    b.Property<string>("Subject")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("UrlAction")
                        .HasColumnType("character varying(1024)")
                        .HasMaxLength(1024);

                    b.Property<DateTime?>("ViewDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ViewNetworkInfo")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("StatusRequestId");

                    b.ToTable("InboxRequest");
                });

            modelBuilder.Entity("KK.Workflow.Service.DataContext.ProcessActivity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ActivityIndex")
                        .HasColumnType("integer");

                    b.Property<string>("ApprovalJavascriptAction")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("character varying(24)")
                        .HasMaxLength(24);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DisplayName")
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<decimal?>("EndValue")
                        .HasColumnType("numeric");

                    b.Property<int>("MinimumApprovalCount")
                        .HasColumnType("integer");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("character varying(24)")
                        .HasMaxLength(24);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("NewStatus")
                        .HasColumnType("integer")
                        .HasMaxLength(32);

                    b.Property<string>("Other01JavascriptAction")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Other02JavascriptAction")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Other03JavascriptAction")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Other04JavascriptAction")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PostSubject")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<Guid>("ProcessRequestId")
                        .HasColumnType("uuid");

                    b.Property<byte>("RowStatus")
                        .HasColumnType("smallint");

                    b.Property<int?>("SlaTime")
                        .HasColumnType("integer");

                    b.Property<int>("SlaType")
                        .HasColumnType("integer");

                    b.Property<decimal?>("StartValue")
                        .HasColumnType("numeric");

                    b.Property<string>("SubjectName")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("UrlAction")
                        .HasColumnType("character varying(1024)")
                        .HasMaxLength(1024);

                    b.Property<int?>("UrlActionType")
                        .HasColumnType("integer");

                    b.Property<string>("ViewJavascriptAction")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("ViewSubject")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("ProcessRequestId");

                    b.ToTable("ProcessActivity");
                });

            modelBuilder.Entity("KK.Workflow.Service.DataContext.ProcessActivityActor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ActionType")
                        .HasColumnType("integer");

                    b.Property<string>("ActorCode")
                        .IsRequired()
                        .HasColumnType("character varying(24)")
                        .HasMaxLength(24);

                    b.Property<string>("ActorEmail")
                        .IsRequired()
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ActorName")
                        .IsRequired()
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<string>("ActorPosition")
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("character varying(24)")
                        .HasMaxLength(24);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("ProcessActivityId")
                        .HasColumnType("uuid");

                    b.Property<byte>("RowStatus")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("ProcessActivityId");

                    b.ToTable("ProcessActivityActor");
                });

            modelBuilder.Entity("KK.Workflow.Service.DataContext.ProcessRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CompanyCode")
                        .IsRequired()
                        .HasColumnType("character varying(6)")
                        .HasMaxLength(6);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("character varying(24)")
                        .HasMaxLength(24);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("EndActive")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("character varying(24)")
                        .HasMaxLength(24);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModuleCode")
                        .IsRequired()
                        .HasColumnType("character varying(12)")
                        .HasMaxLength(12);

                    b.Property<string>("ModuleDescription")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("ModuleName")
                        .IsRequired()
                        .HasColumnType("character varying(32)")
                        .HasMaxLength(32);

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<byte>("RowStatus")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("StartActive")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("WorkflowId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("WorkflowId");

                    b.ToTable("ProcessRequest");
                });

            modelBuilder.Entity("KK.Workflow.Service.DataContext.StatusRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ActorCode")
                        .IsRequired()
                        .HasColumnType("character varying(24)")
                        .HasMaxLength(24);

                    b.Property<string>("ActorName")
                        .IsRequired()
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<DateTime?>("CommitmentDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("CompleteDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("character varying(24)")
                        .HasMaxLength(24);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DisplayStatus")
                        .IsRequired()
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<string>("DocumentName")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("DocumentNumber")
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<bool>("IsComplete")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastAssignDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastAssignTo")
                        .HasColumnType("character varying(24)")
                        .HasMaxLength(24);

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("NewRequestStatus")
                        .HasColumnType("integer");

                    b.Property<string>("Notes")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<Guid>("ProcessActivityId")
                        .HasColumnType("uuid");

                    b.Property<string>("ReferenceKey")
                        .IsRequired()
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RequestNumber")
                        .IsRequired()
                        .HasColumnType("character varying(32)")
                        .HasMaxLength(32);

                    b.Property<byte>("RowStatus")
                        .HasColumnType("smallint");

                    b.Property<int?>("SlaTime")
                        .HasColumnType("integer");

                    b.Property<int>("SlaType")
                        .HasColumnType("integer");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("ProcessActivityId");

                    b.ToTable("StatusRequest");
                });

            modelBuilder.Entity("KK.Workflow.Service.DataContext.TemplateProcessActivity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ActivityIndex")
                        .HasColumnType("integer");

                    b.Property<string>("ApprovalJavascriptAction")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("character varying(24)")
                        .HasMaxLength(24);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DisplayName")
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<decimal?>("EndValue")
                        .HasColumnType("numeric");

                    b.Property<int>("MinimumApprovalCount")
                        .HasColumnType("integer");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("character varying(24)")
                        .HasMaxLength(24);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("NewStatus")
                        .HasColumnType("integer");

                    b.Property<string>("Other01JavascriptAction")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Other02JavascriptAction")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Other03JavascriptAction")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Other04JavascriptAction")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PostSubject")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<Guid>("ProcessRequestId")
                        .HasColumnType("uuid");

                    b.Property<byte>("RowStatus")
                        .HasColumnType("smallint");

                    b.Property<int?>("SlaTime")
                        .HasColumnType("integer");

                    b.Property<int>("SlaType")
                        .HasColumnType("integer");

                    b.Property<decimal?>("StartValue")
                        .HasColumnType("numeric");

                    b.Property<string>("SubjectName")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("UrlAction")
                        .HasColumnType("character varying(1024)")
                        .HasMaxLength(1024);

                    b.Property<int?>("UrlActionType")
                        .HasColumnType("integer");

                    b.Property<string>("ViewJavascriptAction")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("ViewSubject")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("ProcessRequestId");

                    b.ToTable("TemplateProcessActivities");
                });

            modelBuilder.Entity("KK.Workflow.Service.DataContext.TemplateProcessActivityActor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ActionType")
                        .HasColumnType("integer");

                    b.Property<string>("ActorCode")
                        .IsRequired()
                        .HasColumnType("character varying(24)")
                        .HasMaxLength(24);

                    b.Property<string>("ActorEmail")
                        .IsRequired()
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ActorName")
                        .IsRequired()
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<string>("ActorPosition")
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("character varying(24)")
                        .HasMaxLength(24);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("ProcessActivityId")
                        .HasColumnType("uuid");

                    b.Property<byte>("RowStatus")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("ProcessActivityId");

                    b.ToTable("TemplateProcessActivityActors");
                });

            modelBuilder.Entity("KK.Workflow.Service.DataContext.TemplateProcessRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CompanyCode")
                        .IsRequired()
                        .HasColumnType("character varying(6)")
                        .HasMaxLength(6);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("character varying(24)")
                        .HasMaxLength(24);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("EndActive")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("character varying(24)")
                        .HasMaxLength(24);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModuleCode")
                        .IsRequired()
                        .HasColumnType("character varying(12)")
                        .HasMaxLength(12);

                    b.Property<string>("ModuleDescription")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("ModuleName")
                        .IsRequired()
                        .HasColumnType("character varying(32)")
                        .HasMaxLength(32);

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<byte>("RowStatus")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("StartActive")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("WorkflowId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("WorkflowId");

                    b.HasIndex("CompanyCode", "ModuleCode")
                        .IsUnique();

                    b.ToTable("TemplateProcessRequests");
                });

            modelBuilder.Entity("KK.Workflow.Service.DataContext.WorkflowRegistry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("character varying(24)")
                        .HasMaxLength(24);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<byte>("RowStatus")
                        .HasColumnType("smallint");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("character varying(12)")
                        .HasMaxLength(12);

                    b.Property<string>("WorkflowCode")
                        .HasColumnType("character varying(12)")
                        .HasMaxLength(12);

                    b.Property<string>("WorkflowName")
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("WorkflowCode")
                        .IsUnique();

                    b.ToTable("WorkflowRegistries");
                });

            modelBuilder.Entity("KK.Workflow.Service.DataContext.InboxRequest", b =>
                {
                    b.HasOne("KK.Workflow.Service.DataContext.StatusRequest", "StatusRequest")
                        .WithMany("InboxRequests")
                        .HasForeignKey("StatusRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KK.Workflow.Service.DataContext.ProcessActivity", b =>
                {
                    b.HasOne("KK.Workflow.Service.DataContext.ProcessRequest", "ProcessRequest")
                        .WithMany("ProcessActivities")
                        .HasForeignKey("ProcessRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KK.Workflow.Service.DataContext.ProcessActivityActor", b =>
                {
                    b.HasOne("KK.Workflow.Service.DataContext.ProcessActivity", "ProcessActivity")
                        .WithMany("ProcessActivityActors")
                        .HasForeignKey("ProcessActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KK.Workflow.Service.DataContext.ProcessRequest", b =>
                {
                    b.HasOne("KK.Workflow.Service.DataContext.WorkflowRegistry", "WorkflowRegistry")
                        .WithMany("ProcessRequests")
                        .HasForeignKey("WorkflowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KK.Workflow.Service.DataContext.StatusRequest", b =>
                {
                    b.HasOne("KK.Workflow.Service.DataContext.ProcessActivity", "ProcessActivity")
                        .WithMany("StatusRequests")
                        .HasForeignKey("ProcessActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KK.Workflow.Service.DataContext.TemplateProcessActivity", b =>
                {
                    b.HasOne("KK.Workflow.Service.DataContext.TemplateProcessRequest", "TemplateProcessRequest")
                        .WithMany("TemplateProcessActivities")
                        .HasForeignKey("ProcessRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KK.Workflow.Service.DataContext.TemplateProcessActivityActor", b =>
                {
                    b.HasOne("KK.Workflow.Service.DataContext.TemplateProcessActivity", "TemplateProcessActivity")
                        .WithMany("TemplateProcessActivityActors")
                        .HasForeignKey("ProcessActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KK.Workflow.Service.DataContext.TemplateProcessRequest", b =>
                {
                    b.HasOne("KK.Workflow.Service.DataContext.WorkflowRegistry", "WorkflowRegistry")
                        .WithMany("TemplateProcessRequests")
                        .HasForeignKey("WorkflowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}