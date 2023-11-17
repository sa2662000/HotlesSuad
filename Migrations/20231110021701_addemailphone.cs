using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotles.Migrations
{
    /// <inheritdoc />
    public partial class addemailphone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "hotles",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "hotles",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "hotles");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "hotles");
        }
    }
}
