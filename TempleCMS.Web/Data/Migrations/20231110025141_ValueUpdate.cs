using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TempleCMS.Web.Data.Migrations
{
    public partial class ValueUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "Values");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Videos",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Images",
                type: "longtext",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Values",
                type: "longtext",
                nullable: false);
        }
    }
}
