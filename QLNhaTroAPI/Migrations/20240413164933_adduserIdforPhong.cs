using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLNhaTroAPI.Migrations
{
    public partial class adduserIdforPhong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Phong",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Phong");
        }
    }
}
