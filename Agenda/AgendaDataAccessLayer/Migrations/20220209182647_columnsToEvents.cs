using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaDataAccessLayer.Migrations
{
    public partial class columnsToEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Events",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "Events");
        }
    }
}
