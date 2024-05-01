using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLNhaTroAPI.Migrations
{
    public partial class AddUserId_forBangGia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {           
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BangGia",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BangGia");
        }
    }
}
