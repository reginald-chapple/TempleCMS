using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TempleCMS.Web.Data.Migrations
{
    public partial class SmallUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsOpen",
                table: "Groups",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOpen",
                table: "Groups");

            migrationBuilder.AddColumn<long>(
                name: "GroupId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
