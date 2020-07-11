using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KK.Workflow.Service.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkflowRegistries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<byte>(nullable: false),
                    WorkflowName = table.Column<string>(maxLength: 64, nullable: true),
                    WorkflowCode = table.Column<string>(maxLength: 12, nullable: true),
                    Version = table.Column<string>(maxLength: 12, nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 24, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowRegistries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<byte>(nullable: false),
                    CompanyCode = table.Column<string>(maxLength: 6, nullable: false),
                    ModuleCode = table.Column<string>(maxLength: 12, nullable: false),
                    ModuleName = table.Column<string>(maxLength: 32, nullable: false),
                    ModuleDescription = table.Column<string>(maxLength: 256, nullable: true),
                    StartActive = table.Column<DateTime>(nullable: false),
                    EndActive = table.Column<DateTime>(nullable: false),
                    WorkflowId = table.Column<Guid>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 24, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 24, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessRequest_WorkflowRegistries_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "WorkflowRegistries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateProcessRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<byte>(nullable: false),
                    CompanyCode = table.Column<string>(maxLength: 6, nullable: false),
                    ModuleCode = table.Column<string>(maxLength: 12, nullable: false),
                    ModuleName = table.Column<string>(maxLength: 32, nullable: false),
                    ModuleDescription = table.Column<string>(maxLength: 256, nullable: true),
                    StartActive = table.Column<DateTime>(nullable: false),
                    EndActive = table.Column<DateTime>(nullable: false),
                    WorkflowId = table.Column<Guid>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 24, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 24, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateProcessRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateProcessRequests_WorkflowRegistries_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "WorkflowRegistries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessActivity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<byte>(nullable: false),
                    ProcessRequestId = table.Column<Guid>(nullable: false),
                    ActivityIndex = table.Column<int>(nullable: false),
                    SubjectName = table.Column<string>(maxLength: 128, nullable: true),
                    ViewSubject = table.Column<string>(maxLength: 128, nullable: true),
                    PostSubject = table.Column<string>(maxLength: 128, nullable: true),
                    NewStatus = table.Column<int>(maxLength: 32, nullable: false),
                    MinimumApprovalCount = table.Column<int>(nullable: false),
                    DisplayName = table.Column<string>(maxLength: 64, nullable: true),
                    StartValue = table.Column<decimal>(nullable: true),
                    EndValue = table.Column<decimal>(nullable: true),
                    SlaType = table.Column<int>(nullable: false),
                    SlaTime = table.Column<int>(nullable: true),
                    UrlActionType = table.Column<int>(nullable: true),
                    UrlAction = table.Column<string>(maxLength: 1024, nullable: true),
                    ApprovalJavascriptAction = table.Column<string>(maxLength: 256, nullable: true),
                    ViewJavascriptAction = table.Column<string>(maxLength: 256, nullable: true),
                    Other01JavascriptAction = table.Column<string>(maxLength: 256, nullable: true),
                    Other02JavascriptAction = table.Column<string>(maxLength: 256, nullable: true),
                    Other03JavascriptAction = table.Column<string>(maxLength: 256, nullable: true),
                    Other04JavascriptAction = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 24, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 24, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessActivity_ProcessRequest_ProcessRequestId",
                        column: x => x.ProcessRequestId,
                        principalTable: "ProcessRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateProcessActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<byte>(nullable: false),
                    ProcessRequestId = table.Column<Guid>(nullable: false),
                    ActivityIndex = table.Column<int>(nullable: false),
                    SubjectName = table.Column<string>(maxLength: 128, nullable: true),
                    ViewSubject = table.Column<string>(maxLength: 128, nullable: true),
                    PostSubject = table.Column<string>(maxLength: 128, nullable: true),
                    NewStatus = table.Column<int>(nullable: false),
                    MinimumApprovalCount = table.Column<int>(nullable: false),
                    DisplayName = table.Column<string>(maxLength: 64, nullable: true),
                    StartValue = table.Column<decimal>(nullable: true),
                    EndValue = table.Column<decimal>(nullable: true),
                    SlaType = table.Column<int>(nullable: false),
                    SlaTime = table.Column<int>(nullable: true),
                    UrlActionType = table.Column<int>(nullable: true),
                    UrlAction = table.Column<string>(maxLength: 1024, nullable: true),
                    ApprovalJavascriptAction = table.Column<string>(maxLength: 256, nullable: true),
                    ViewJavascriptAction = table.Column<string>(maxLength: 256, nullable: true),
                    Other01JavascriptAction = table.Column<string>(maxLength: 256, nullable: true),
                    Other02JavascriptAction = table.Column<string>(maxLength: 256, nullable: true),
                    Other03JavascriptAction = table.Column<string>(maxLength: 256, nullable: true),
                    Other04JavascriptAction = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 24, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 24, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateProcessActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateProcessActivities_TemplateProcessRequests_ProcessRe~",
                        column: x => x.ProcessRequestId,
                        principalTable: "TemplateProcessRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessActivityActor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<byte>(nullable: false),
                    ProcessActivityId = table.Column<Guid>(nullable: false),
                    ActorCode = table.Column<string>(maxLength: 24, nullable: false),
                    ActorName = table.Column<string>(maxLength: 64, nullable: false),
                    ActorPosition = table.Column<string>(maxLength: 64, nullable: true),
                    ActionType = table.Column<int>(nullable: false),
                    ActorEmail = table.Column<string>(maxLength: 128, nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 24, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessActivityActor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessActivityActor_ProcessActivity_ProcessActivityId",
                        column: x => x.ProcessActivityId,
                        principalTable: "ProcessActivity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<byte>(nullable: false),
                    ProcessActivityId = table.Column<Guid>(nullable: false),
                    ReferenceKey = table.Column<string>(maxLength: 64, nullable: false),
                    RequestNumber = table.Column<string>(maxLength: 32, nullable: false),
                    DocumentName = table.Column<string>(maxLength: 128, nullable: true),
                    DocumentNumber = table.Column<string>(maxLength: 64, nullable: true),
                    NewRequestStatus = table.Column<int>(nullable: false),
                    DisplayStatus = table.Column<string>(maxLength: 64, nullable: false),
                    ActorCode = table.Column<string>(maxLength: 24, nullable: false),
                    ActorName = table.Column<string>(maxLength: 64, nullable: false),
                    IsComplete = table.Column<bool>(nullable: false),
                    CompleteDate = table.Column<DateTime>(nullable: true),
                    Subject = table.Column<string>(maxLength: 128, nullable: false),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    LastAssignTo = table.Column<string>(maxLength: 24, nullable: true),
                    LastAssignDate = table.Column<DateTime>(nullable: true),
                    CommitmentDate = table.Column<DateTime>(nullable: true),
                    SlaType = table.Column<int>(nullable: false),
                    SlaTime = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(maxLength: 128, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 24, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusRequest_ProcessActivity_ProcessActivityId",
                        column: x => x.ProcessActivityId,
                        principalTable: "ProcessActivity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateProcessActivityActors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<byte>(nullable: false),
                    ProcessActivityId = table.Column<Guid>(nullable: false),
                    ActorCode = table.Column<string>(maxLength: 24, nullable: false),
                    ActorName = table.Column<string>(maxLength: 64, nullable: false),
                    ActorPosition = table.Column<string>(maxLength: 64, nullable: true),
                    ActionType = table.Column<int>(nullable: false),
                    ActorEmail = table.Column<string>(maxLength: 128, nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 24, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateProcessActivityActors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateProcessActivityActors_TemplateProcessActivities_Pro~",
                        column: x => x.ProcessActivityId,
                        principalTable: "TemplateProcessActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InboxRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<byte>(nullable: false),
                    StatusRequestId = table.Column<Guid>(nullable: false),
                    RequestNumber = table.Column<string>(maxLength: 32, nullable: false),
                    ReferenceKey = table.Column<string>(maxLength: 64, nullable: false),
                    DocumentName = table.Column<string>(maxLength: 128, nullable: true),
                    DocumentNumber = table.Column<string>(maxLength: 64, nullable: true),
                    ActorCodeRequester = table.Column<string>(maxLength: 24, nullable: false),
                    ActorNameRequester = table.Column<string>(maxLength: 64, nullable: false),
                    AssignDate = table.Column<DateTime>(nullable: false),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    Subject = table.Column<string>(maxLength: 128, nullable: true),
                    CommitmentDate = table.Column<DateTime>(nullable: true),
                    ActorCodeAssignees = table.Column<string>(maxLength: 24, nullable: false),
                    ActorNameAssignees = table.Column<string>(maxLength: 64, nullable: false),
                    IsComplete = table.Column<bool>(nullable: false),
                    RequestStatus = table.Column<int>(nullable: false),
                    DisplayStatus = table.Column<string>(maxLength: 64, nullable: false),
                    CompleteDate = table.Column<DateTime>(nullable: true),
                    HasView = table.Column<bool>(nullable: false),
                    ViewDate = table.Column<DateTime>(nullable: true),
                    ViewNetworkInfo = table.Column<string>(nullable: true),
                    ActionType = table.Column<int>(nullable: false),
                    UrlAction = table.Column<string>(maxLength: 1024, nullable: true),
                    JavascriptAction = table.Column<string>(maxLength: 1024, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 24, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 24, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboxRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InboxRequest_StatusRequest_StatusRequestId",
                        column: x => x.StatusRequestId,
                        principalTable: "StatusRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InboxRequest_StatusRequestId",
                table: "InboxRequest",
                column: "StatusRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessActivity_ProcessRequestId",
                table: "ProcessActivity",
                column: "ProcessRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessActivityActor_ProcessActivityId",
                table: "ProcessActivityActor",
                column: "ProcessActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessRequest_WorkflowId",
                table: "ProcessRequest",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusRequest_ProcessActivityId",
                table: "StatusRequest",
                column: "ProcessActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateProcessActivities_ProcessRequestId",
                table: "TemplateProcessActivities",
                column: "ProcessRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateProcessActivityActors_ProcessActivityId",
                table: "TemplateProcessActivityActors",
                column: "ProcessActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateProcessRequests_WorkflowId",
                table: "TemplateProcessRequests",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateProcessRequests_CompanyCode_ModuleCode",
                table: "TemplateProcessRequests",
                columns: new[] { "CompanyCode", "ModuleCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowRegistries_WorkflowCode",
                table: "WorkflowRegistries",
                column: "WorkflowCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InboxRequest");

            migrationBuilder.DropTable(
                name: "ProcessActivityActor");

            migrationBuilder.DropTable(
                name: "TemplateProcessActivityActors");

            migrationBuilder.DropTable(
                name: "StatusRequest");

            migrationBuilder.DropTable(
                name: "TemplateProcessActivities");

            migrationBuilder.DropTable(
                name: "ProcessActivity");

            migrationBuilder.DropTable(
                name: "TemplateProcessRequests");

            migrationBuilder.DropTable(
                name: "ProcessRequest");

            migrationBuilder.DropTable(
                name: "WorkflowRegistries");
        }
    }
}
