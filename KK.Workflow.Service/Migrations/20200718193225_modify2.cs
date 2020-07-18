using Microsoft.EntityFrameworkCore.Migrations;

namespace KK.Workflow.Service.Migrations
{
    public partial class modify2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceKey",
                table: "StatusRequests");

            migrationBuilder.DropColumn(
                name: "ReferenceKey",
                table: "RequestActivities");

            migrationBuilder.DropColumn(
                name: "ReferenceKey",
                table: "InboxRequests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReferenceKey",
                table: "StatusRequests",
                type: "character varying(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReferenceKey",
                table: "RequestActivities",
                type: "character varying(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReferenceKey",
                table: "InboxRequests",
                type: "character varying(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");
        }
    }
}
