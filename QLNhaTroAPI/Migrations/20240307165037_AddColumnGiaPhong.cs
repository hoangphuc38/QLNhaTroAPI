using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLNhaTroAPI.Migrations
{
    public partial class AddColumnGiaPhong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "GiaPhong",
                table: "Phong",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiaPhong",
                table: "Phong");
        }
    }
}
