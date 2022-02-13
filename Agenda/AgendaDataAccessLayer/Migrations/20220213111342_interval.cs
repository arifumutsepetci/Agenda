using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaDataAccessLayer.Migrations
{
    public partial class interval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventUrgency_EventUrgencyId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_EventUrgencyId",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "Explanation",
                table: "Events",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<DateTime>(
                name: "EventDateIntervalStart",
                table: "Events",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventDateIntervalStart",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "Explanation",
                table: "Events",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventUrgencyId",
                table: "Events",
                column: "EventUrgencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventUrgency_EventUrgencyId",
                table: "Events",
                column: "EventUrgencyId",
                principalTable: "EventUrgency",
                principalColumn: "ObjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
