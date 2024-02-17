using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.db.Migrations
{
    public partial class AuthUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorizeUsers",
                columns: table => new
                {
                    USER_KEY = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USER_ROLE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ENT_USER_KEY = table.Column<int>(type: "int", nullable: false),
                    ENT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EDIT_USER_KEY = table.Column<int>(type: "int", nullable: false),
                    EDIT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TAG_ACTIVE = table.Column<byte>(type: "tinyint", nullable: false),
                    TAG_DELETE = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizeUsers", x => x.USER_KEY);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorizeUsers");
        }
    }
}
