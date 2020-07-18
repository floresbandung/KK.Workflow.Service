using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KK.Workflow.Service.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InboxRequest_StatusRequest_StatusRequestId",
                table: "InboxRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessActivity_ProcessRequest_ProcessRequestId",
                table: "ProcessActivity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessActivityActor_ProcessActivity_ProcessActivityId",
                table: "ProcessActivityActor");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessRequest_WorkflowRegistries_WorkflowId",
                table: "ProcessRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusRequest_ProcessActivity_ProcessActivityId",
                table: "StatusRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusRequest",
                table: "StatusRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessRequest",
                table: "ProcessRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessActivityActor",
                table: "ProcessActivityActor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessActivity",
                table: "ProcessActivity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InboxRequest",
                table: "InboxRequest");

            migrationBuilder.RenameTable(
                name: "StatusRequest",
                newName: "StatusRequests");

            migrationBuilder.RenameTable(
                name: "ProcessRequest",
                newName: "ProcessRequests");

            migrationBuilder.RenameTable(
                name: "ProcessActivityActor",
                newName: "ProcessActivityActors");

            migrationBuilder.RenameTable(
                name: "ProcessActivity",
                newName: "ProcessActivities");

            migrationBuilder.RenameTable(
                name: "InboxRequest",
                newName: "InboxRequests");

            migrationBuilder.RenameIndex(
                name: "IX_StatusRequest_ProcessActivityId",
                table: "StatusRequests",
                newName: "IX_StatusRequests_ProcessActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_ProcessRequest_WorkflowId",
                table: "ProcessRequests",
                newName: "IX_ProcessRequests_WorkflowId");

            migrationBuilder.RenameIndex(
                name: "IX_ProcessActivityActor_ProcessActivityId",
                table: "ProcessActivityActors",
                newName: "IX_ProcessActivityActors_ProcessActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_ProcessActivity_ProcessRequestId",
                table: "ProcessActivities",
                newName: "IX_ProcessActivities_ProcessRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_InboxRequest_StatusRequestId",
                table: "InboxRequests",
                newName: "IX_InboxRequests_StatusRequestId");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "StatusRequests",
                maxLength: 24,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestNumber",
                table: "ProcessRequests",
                maxLength: 24,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusRequests",
                table: "StatusRequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessRequests",
                table: "ProcessRequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessActivityActors",
                table: "ProcessActivityActors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessActivities",
                table: "ProcessActivities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InboxRequests",
                table: "InboxRequests",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ConfigurationNumbers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    TypeSuffixChar = table.Column<string>(maxLength: 24, nullable: true),
                    SuffixChar = table.Column<string>(maxLength: 6, nullable: true),
                    LastIndex = table.Column<int>(nullable: false),
                    LengthNumber = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 24, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 24, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<byte>(nullable: false),
                    TaskFrom = table.Column<string>(maxLength: 24, nullable: false),
                    SourceId = table.Column<Guid>(nullable: false),
                    EmailFrom = table.Column<string>(maxLength: 128, nullable: true),
                    EmailTo = table.Column<string>(maxLength: 1280, nullable: true),
                    EmailCc = table.Column<string>(maxLength: 1280, nullable: true),
                    EmailSubject = table.Column<string>(maxLength: 128, nullable: true),
                    EmailBody = table.Column<string>(nullable: true),
                    ResendCount = table.Column<int>(nullable: true),
                    ErrorMessage = table.Column<string>(maxLength: 1024, nullable: true),
                    StartSend = table.Column<DateTime>(nullable: true),
                    EndSend = table.Column<DateTime>(nullable: true),
                    IsSuccess = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 24, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 24, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<byte>(nullable: false),
                    ProcessActivityId = table.Column<Guid>(nullable: false),
                    ReferenceKey = table.Column<string>(maxLength: 64, nullable: false),
                    RequestNumber = table.Column<string>(maxLength: 32, nullable: false),
                    DocumentName = table.Column<string>(maxLength: 128, nullable: true),
                    DocumentNumber = table.Column<string>(maxLength: 64, nullable: true),
                    ActivityIndex = table.Column<int>(nullable: false),
                    ActorCode = table.Column<string>(maxLength: 24, nullable: false),
                    ActorName = table.Column<string>(maxLength: 64, nullable: false),
                    RequestStatus = table.Column<int>(maxLength: 64, nullable: false),
                    DisplayStatus = table.Column<string>(maxLength: 64, nullable: true),
                    SubjectName = table.Column<string>(maxLength: 128, nullable: true),
                    IsComplete = table.Column<bool>(nullable: false),
                    ActionName = table.Column<string>(maxLength: 24, nullable: false),
                    ActionDate = table.Column<DateTime>(nullable: true),
                    SlaType = table.Column<int>(nullable: false),
                    SlaTime = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(maxLength: 128, nullable: true),
                    IpAddress = table.Column<string>(maxLength: 24, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 24, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 24, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestActivities_ProcessActivities_ProcessActivityId",
                        column: x => x.ProcessActivityId,
                        principalTable: "ProcessActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestActivities_ProcessActivityId",
                table: "RequestActivities",
                column: "ProcessActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_InboxRequests_StatusRequests_StatusRequestId",
                table: "InboxRequests",
                column: "StatusRequestId",
                principalTable: "StatusRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessActivities_ProcessRequests_ProcessRequestId",
                table: "ProcessActivities",
                column: "ProcessRequestId",
                principalTable: "ProcessRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessActivityActors_ProcessActivities_ProcessActivityId",
                table: "ProcessActivityActors",
                column: "ProcessActivityId",
                principalTable: "ProcessActivities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessRequests_WorkflowRegistries_WorkflowId",
                table: "ProcessRequests",
                column: "WorkflowId",
                principalTable: "WorkflowRegistries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatusRequests_ProcessActivities_ProcessActivityId",
                table: "StatusRequests",
                column: "ProcessActivityId",
                principalTable: "ProcessActivities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InboxRequests_StatusRequests_StatusRequestId",
                table: "InboxRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessActivities_ProcessRequests_ProcessRequestId",
                table: "ProcessActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessActivityActors_ProcessActivities_ProcessActivityId",
                table: "ProcessActivityActors");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessRequests_WorkflowRegistries_WorkflowId",
                table: "ProcessRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusRequests_ProcessActivities_ProcessActivityId",
                table: "StatusRequests");

            migrationBuilder.DropTable(
                name: "ConfigurationNumbers");

            migrationBuilder.DropTable(
                name: "EmailTasks");

            migrationBuilder.DropTable(
                name: "RequestActivities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusRequests",
                table: "StatusRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessRequests",
                table: "ProcessRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessActivityActors",
                table: "ProcessActivityActors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessActivities",
                table: "ProcessActivities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InboxRequests",
                table: "InboxRequests");

            migrationBuilder.DropColumn(
                name: "RequestNumber",
                table: "ProcessRequests");

            migrationBuilder.RenameTable(
                name: "StatusRequests",
                newName: "StatusRequest");

            migrationBuilder.RenameTable(
                name: "ProcessRequests",
                newName: "ProcessRequest");

            migrationBuilder.RenameTable(
                name: "ProcessActivityActors",
                newName: "ProcessActivityActor");

            migrationBuilder.RenameTable(
                name: "ProcessActivities",
                newName: "ProcessActivity");

            migrationBuilder.RenameTable(
                name: "InboxRequests",
                newName: "InboxRequest");

            migrationBuilder.RenameIndex(
                name: "IX_StatusRequests_ProcessActivityId",
                table: "StatusRequest",
                newName: "IX_StatusRequest_ProcessActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_ProcessRequests_WorkflowId",
                table: "ProcessRequest",
                newName: "IX_ProcessRequest_WorkflowId");

            migrationBuilder.RenameIndex(
                name: "IX_ProcessActivityActors_ProcessActivityId",
                table: "ProcessActivityActor",
                newName: "IX_ProcessActivityActor_ProcessActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_ProcessActivities_ProcessRequestId",
                table: "ProcessActivity",
                newName: "IX_ProcessActivity_ProcessRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_InboxRequests_StatusRequestId",
                table: "InboxRequest",
                newName: "IX_InboxRequest_StatusRequestId");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "StatusRequest",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 24,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusRequest",
                table: "StatusRequest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessRequest",
                table: "ProcessRequest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessActivityActor",
                table: "ProcessActivityActor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessActivity",
                table: "ProcessActivity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InboxRequest",
                table: "InboxRequest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InboxRequest_StatusRequest_StatusRequestId",
                table: "InboxRequest",
                column: "StatusRequestId",
                principalTable: "StatusRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessActivity_ProcessRequest_ProcessRequestId",
                table: "ProcessActivity",
                column: "ProcessRequestId",
                principalTable: "ProcessRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessActivityActor_ProcessActivity_ProcessActivityId",
                table: "ProcessActivityActor",
                column: "ProcessActivityId",
                principalTable: "ProcessActivity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessRequest_WorkflowRegistries_WorkflowId",
                table: "ProcessRequest",
                column: "WorkflowId",
                principalTable: "WorkflowRegistries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatusRequest_ProcessActivity_ProcessActivityId",
                table: "StatusRequest",
                column: "ProcessActivityId",
                principalTable: "ProcessActivity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
