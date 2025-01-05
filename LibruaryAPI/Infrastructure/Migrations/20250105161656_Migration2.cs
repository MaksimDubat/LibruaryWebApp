using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibruaryAPI.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AppRoles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AppRoles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AppRoles");

            migrationBuilder.DropColumn(
                name: "NormalizedName",
                table: "AppRoles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AppRoles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AppRoles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AppRoles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedName",
                table: "AppRoles",
                type: "text",
                nullable: true);
        }
    }
}
