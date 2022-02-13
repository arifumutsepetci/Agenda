using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaDataAccessLayer.Migrations
{
    public partial class isreminder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReminder",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReminder",
                table: "Events");
        }
    }
}
