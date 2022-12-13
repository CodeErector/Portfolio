using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeErector.Migrations
{
    public partial class intialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    massage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.ContactId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactDetails");
        }
    }
}
