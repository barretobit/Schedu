using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schedu.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    BusinessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    BusinessPhone = table.Column<int>(type: "int", nullable: false),
                    BusinessEmail = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(35)", nullable: false),
                    OwnerPhone = table.Column<int>(type: "int", nullable: false),
                    OwnerEmail = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    RegistryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.BusinessId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Businesses");
        }
    }
}
