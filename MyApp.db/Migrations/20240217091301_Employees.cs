using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.db.Migrations
{
    public partial class Employees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    MAST_EMPLOYEE_KEY = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FULLNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PHONE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ENT_USER_KEY = table.Column<int>(type: "int", nullable: false),
                    ENT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EDIT_USER_KEY = table.Column<int>(type: "int", nullable: false),
                    EDIT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TAG_ACTIVE = table.Column<byte>(type: "tinyint", nullable: false),
                    TAG_DELETE = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.MAST_EMPLOYEE_KEY);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
