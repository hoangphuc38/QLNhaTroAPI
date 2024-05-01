using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLNhaTroAPI.Migrations
{
    public partial class AddUserID_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TongKetThang",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TongKetThang");
        }
    }
}
