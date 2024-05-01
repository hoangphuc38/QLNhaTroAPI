﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QLNhaTroAPI.Data;

#nullable disable

namespace QLNhaTroAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QLNhaTroAPI.Models.BangGia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DonVi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Gia")
                        .HasColumnType("float");

                    b.Property<string>("HangMuc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BangGia");
                });

            modelBuilder.Entity("QLNhaTroAPI.Models.HoaDonPhong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayHoaDon")
                        .HasColumnType("datetime2");

                    b.Property<int>("PhongId")
                        .HasColumnType("int");

                    b.Property<double>("SoDienThangNay")
                        .HasColumnType("float");

                    b.Property<double>("SoDienThangTruoc")
                        .HasColumnType("float");

                    b.Property<double>("SoNgayO")
                        .HasColumnType("float");

                    b.Property<double>("SoNuocThangNay")
                        .HasColumnType("float");

                    b.Property<double>("SoNuocThangTruoc")
                        .HasColumnType("float");

                    b.Property<double>("TongGiaDien")
                        .HasColumnType("float");

                    b.Property<double>("TongGiaNuoc")
                        .HasColumnType("float");

                    b.Property<double>("TongHoaDon")
                        .HasColumnType("float");

                    b.Property<int?>("TongKetId")
                        .HasColumnType("int");

                    b.Property<double>("TongSoDien")
                        .HasColumnType("float");

                    b.Property<double>("TongSoNuoc")
                        .HasColumnType("float");

                    b.Property<double>("TongTienPhong")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PhongId");

                    b.HasIndex("TongKetId");

                    b.ToTable("HoaDonPhong");
                });

            modelBuilder.Entity("QLNhaTroAPI.Models.Nguoi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CCCD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("DangO")
                        .HasColumnType("bit");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsNam")
                        .HasColumnType("bit");

                    b.Property<string>("NamSinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayDi")
                        .HasColumnType("datetime2");

                    b.Property<string>("NgheNghiep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoiDangKyHoKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PhongId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhongId");

                    b.ToTable("Nguoi");
                });

            modelBuilder.Entity("QLNhaTroAPI.Models.Phong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("GiaPhong")
                        .HasColumnType("float");

                    b.Property<int>("LoaiPhong")
                        .HasColumnType("int");

                    b.Property<string>("TenPhong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Phong");
                });

            modelBuilder.Entity("QLNhaTroAPI.Models.TaiKhoan", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("TaiKhoan");
                });

            modelBuilder.Entity("QLNhaTroAPI.Models.TongKet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("NgayTongKet")
                        .HasColumnType("datetime2");

                    b.Property<double>("TongDien")
                        .HasColumnType("float");

                    b.Property<double>("TongNuoc")
                        .HasColumnType("float");

                    b.Property<double>("TongTienTongKet")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TongKetThang");
                });

            modelBuilder.Entity("QLNhaTroAPI.ViewModels.HoaDonInTongKet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayHoaDon")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PhongId")
                        .HasColumnType("int");

                    b.Property<double?>("SoDienThangNay")
                        .HasColumnType("float");

                    b.Property<double?>("SoDienThangTruoc")
                        .HasColumnType("float");

                    b.Property<double?>("SoNgayO")
                        .HasColumnType("float");

                    b.Property<double?>("SoNuocThangNay")
                        .HasColumnType("float");

                    b.Property<double?>("SoNuocThangTruoc")
                        .HasColumnType("float");

                    b.Property<double?>("TongGiaDien")
                        .HasColumnType("float");

                    b.Property<double?>("TongGiaNuoc")
                        .HasColumnType("float");

                    b.Property<double?>("TongHoaDon")
                        .HasColumnType("float");

                    b.Property<int?>("TongKetId")
                        .HasColumnType("int");

                    b.Property<double?>("TongSoDien")
                        .HasColumnType("float");

                    b.Property<double?>("TongSoNuoc")
                        .HasColumnType("float");

                    b.Property<double?>("TongTienPhong")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PhongId");

                    b.HasIndex("TongKetId");

                    b.ToTable("HoaDonInTongKet");
                });

            modelBuilder.Entity("QLNhaTroAPI.ViewModels.HoaDonPhongVM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayHoaDon")
                        .HasColumnType("datetime2");

                    b.Property<int>("PhongId")
                        .HasColumnType("int");

                    b.Property<double>("SoDienThangNay")
                        .HasColumnType("float");

                    b.Property<double>("SoDienThangTruoc")
                        .HasColumnType("float");

                    b.Property<double>("SoNgayO")
                        .HasColumnType("float");

                    b.Property<double>("SoNuocThangNay")
                        .HasColumnType("float");

                    b.Property<double>("SoNuocThangTruoc")
                        .HasColumnType("float");

                    b.Property<double>("TongGiaDien")
                        .HasColumnType("float");

                    b.Property<double>("TongGiaNuoc")
                        .HasColumnType("float");

                    b.Property<double>("TongHoaDon")
                        .HasColumnType("float");

                    b.Property<int>("TongKetId")
                        .HasColumnType("int");

                    b.Property<double>("TongSoDien")
                        .HasColumnType("float");

                    b.Property<double>("TongSoNuoc")
                        .HasColumnType("float");

                    b.Property<double>("TongTienPhong")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PhongId");

                    b.ToTable("HoaDonPhongVM");
                });

            modelBuilder.Entity("QLNhaTroAPI.ViewModels.NguoiVM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CCCD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("DangO")
                        .HasColumnType("bit");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsNam")
                        .HasColumnType("bit");

                    b.Property<string>("NamSinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayDi")
                        .HasColumnType("datetime2");

                    b.Property<string>("NgheNghiep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoiDangKyHoKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhongId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhongId");

                    b.ToTable("NguoiVM");
                });

            modelBuilder.Entity("QLNhaTroAPI.Models.HoaDonPhong", b =>
                {
                    b.HasOne("QLNhaTroAPI.Models.Phong", "Phong")
                        .WithMany()
                        .HasForeignKey("PhongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLNhaTroAPI.Models.TongKet", "TongKet")
                        .WithMany()
                        .HasForeignKey("TongKetId");

                    b.Navigation("Phong");

                    b.Navigation("TongKet");
                });

            modelBuilder.Entity("QLNhaTroAPI.Models.Nguoi", b =>
                {
                    b.HasOne("QLNhaTroAPI.Models.Phong", "Phong")
                        .WithMany()
                        .HasForeignKey("PhongId");

                    b.Navigation("Phong");
                });

            modelBuilder.Entity("QLNhaTroAPI.ViewModels.HoaDonInTongKet", b =>
                {
                    b.HasOne("QLNhaTroAPI.Models.Phong", "Phong")
                        .WithMany()
                        .HasForeignKey("PhongId");

                    b.HasOne("QLNhaTroAPI.Models.TongKet", null)
                        .WithMany("DanhSachHoaDon")
                        .HasForeignKey("TongKetId");

                    b.Navigation("Phong");
                });

            modelBuilder.Entity("QLNhaTroAPI.ViewModels.HoaDonPhongVM", b =>
                {
                    b.HasOne("QLNhaTroAPI.Models.Phong", null)
                        .WithMany("DanhSachHoaDon")
                        .HasForeignKey("PhongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QLNhaTroAPI.ViewModels.NguoiVM", b =>
                {
                    b.HasOne("QLNhaTroAPI.Models.Phong", null)
                        .WithMany("DanhSachNguoi")
                        .HasForeignKey("PhongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QLNhaTroAPI.Models.Phong", b =>
                {
                    b.Navigation("DanhSachHoaDon");

                    b.Navigation("DanhSachNguoi");
                });

            modelBuilder.Entity("QLNhaTroAPI.Models.TongKet", b =>
                {
                    b.Navigation("DanhSachHoaDon");
                });
#pragma warning restore 612, 618
        }
    }
}
