using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sheduler.RestApi.Migrations
{
    public partial class RenameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Users_ApprovingId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Users_CreatorId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Users_ReplacingId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Post_PostId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Request",
                table: "Request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.RenameTable(
                name: "Request",
                newName: "Requests");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts");

            migrationBuilder.RenameIndex(
                name: "IX_Request_ReplacingId",
                table: "Requests",
                newName: "IX_Requests_ReplacingId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_CreatorId",
                table: "Requests",
                newName: "IX_Requests_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_ApprovingId",
                table: "Requests",
                newName: "IX_Requests_ApprovingId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_Name",
                table: "Posts",
                newName: "IX_Posts_Name");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendingDate",
                table: "Requests",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                table: "Requests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_ApprovingId",
                table: "Requests",
                column: "ApprovingId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_CreatorId",
                table: "Requests",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_ReplacingId",
                table: "Requests",
                column: "ReplacingId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Posts_PostId",
                table: "Users",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_ApprovingId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_CreatorId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_ReplacingId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Posts_PostId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Requests",
                newName: "Request");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_ReplacingId",
                table: "Request",
                newName: "IX_Request_ReplacingId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_CreatorId",
                table: "Request",
                newName: "IX_Request_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_ApprovingId",
                table: "Request",
                newName: "IX_Request_ApprovingId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_Name",
                table: "Post",
                newName: "IX_Post_Name");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendingDate",
                table: "Request",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Request",
                table: "Request",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Users_ApprovingId",
                table: "Request",
                column: "ApprovingId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Users_CreatorId",
                table: "Request",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Users_ReplacingId",
                table: "Request",
                column: "ReplacingId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Post_PostId",
                table: "Users",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
