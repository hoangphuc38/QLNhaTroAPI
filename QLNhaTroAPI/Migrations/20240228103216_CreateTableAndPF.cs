using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLNhaTroAPI.Migrations
{
    public partial class CreateTableAndPF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BangGia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HangMuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gia = table.Column<double>(type: "float", nullable: false),
                    DonVi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangGia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiPhong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TongKetThang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayTongKet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongDien = table.Column<double>(type: "float", nullable: false),
                    TongNuoc = table.Column<double>(type: "float", nullable: false),
                    TongTienTongKet = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TongKetThang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nguoi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamSinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsNam = table.Column<bool>(type: "bit", nullable: true),
                    NoiDangKyHoKhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CCCD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgheNghiep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DangO = table.Column<bool>(type: "bit", nullable: true),
                    NgayDi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhongId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nguoi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nguoi_Phong_PhongId",
                        column: x => x.PhongId,
                        principalTable: "Phong",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HoaDonPhong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhongId = table.Column<int>(type: "int", nullable: false),
                    NgayHoaDon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoDienThangTruoc = table.Column<double>(type: "float", nullable: true),
                    SoDienThangNay = table.Column<double>(type: "float", nullable: true),
                    TongSoDien = table.Column<double>(type: "float", nullable: true),
                    TongGiaDien = table.Column<double>(type: "float", nullable: true),
                    SoNuocThangTruoc = table.Column<double>(type: "float", nullable: true),
                    SoNuocThangNay = table.Column<double>(type: "float", nullable: true),
                    TongSoNuoc = table.Column<double>(type: "float", nullable: true),
                    TongGiaNuoc = table.Column<double>(type: "float", nullable: true),
                    SoNgayO = table.Column<double>(type: "float", nullable: true),
                    TongTienPhong = table.Column<double>(type: "float", nullable: true),
                    TongHoaDon = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TongKetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonPhong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDonPhong_Phong_PhongId",
                        column: x => x.PhongId,
                        principalTable: "Phong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDonPhong_TongKetThang_TongKetId",
                        column: x => x.TongKetId,
                        principalTable: "TongKetThang",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonPhong_PhongId",
                table: "HoaDonPhong",
                column: "PhongId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonPhong_TongKetId",
                table: "HoaDonPhong",
                column: "TongKetId");

            migrationBuilder.CreateIndex(
                name: "IX_Nguoi_PhongId",
                table: "Nguoi",
                column: "PhongId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BangGia");

            migrationBuilder.DropTable(
                name: "HoaDonPhong");

            migrationBuilder.DropTable(
                name: "Nguoi");

            migrationBuilder.DropTable(
                name: "TongKetThang");

            migrationBuilder.DropTable(
                name: "Phong");
        }
    }
}
