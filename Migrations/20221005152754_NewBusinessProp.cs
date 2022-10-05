using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schedu.Migrations
{
    public partial class NewBusinessProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Businesses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Businesses");
        }
    }
}
