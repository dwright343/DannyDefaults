using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DannyDefaults.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Defaults_table",
                columns: table => new
                {
                    DefaultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefaultName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultLetter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultInt = table.Column<int>(type: "int", nullable: false),
                    DefaultDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defaults_table", x => x.DefaultId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Defaults_table");
        }
    }
}
