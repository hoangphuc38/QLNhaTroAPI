using Microsoft.EntityFrameworkCore;
using QLNhaTroAPI.Data;
using QLNhaTroAPI.Models;
using QLNhaTroAPI.Repositories;
using QLNhaTroAPI.ViewModels;

namespace QLNhaTroAPI.Services
{
    public class PhongRepo : IPhongRepo
    {
        private readonly DataContext _context;
        public PhongRepo(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Phong>> GetAll()
        {
            var listPhong = await _context.Phong.ToListAsync();

            foreach (var item in listPhong)
            {
                item.DanhSachNguoi = new List<NguoiVM>();
                item.DanhSachHoaDon = new List<HoaDonPhongVM>();

                var listNguoi = await _context.Nguoi
                    .Where(c => c.Phong.Id == item.Id)
                    .ToListAsync();

                foreach (var itemNguoi in listNguoi)
                {
                    var nguoi = await _context.Nguoi.FindAsync(itemNguoi.Id);
                    if (nguoi != null)
                    {
                        var nguoiPhong = new NguoiVM();
                        nguoiPhong.Id = nguoi.Id;
                        nguoiPhong.HoTen = nguoi.HoTen;
                        nguoiPhong.IsNam = nguoi.IsNam;
                        nguoiPhong.NamSinh = nguoi.NamSinh;
                        nguoiPhong.NoiDangKyHoKhau = nguoi.NoiDangKyHoKhau;
                        nguoiPhong.CCCD = nguoi.CCCD;
                        nguoiPhong.DangO = nguoi.DangO;
                        nguoiPhong.NgayDi = nguoi.NgayDi;
                        nguoiPhong.PhongId = item.Id;
                        item.DanhSachNguoi.Add(nguoiPhong);
                    }
                }
            }

            return listPhong;
        }
        public async Task<Phong> GetDetailPhong(int id)
        {
            Phong phongVM = new Phong();
            phongVM.DanhSachNguoi = new List<NguoiVM>();
            phongVM.DanhSachHoaDon = new List<HoaDonPhongVM>();

            var phong = await _context.Phong.FindAsync(id);
            var listNguoi = await _context.Nguoi
                .Where(c => c.Phong.Id == id)
                .ToListAsync();

            if (phong == null)
            {
                throw new KeyNotFoundException(id.ToString());
            }
            else
            {
                phongVM.Id = phong.Id;
                phongVM.TenPhong = phong.TenPhong;
                phongVM.LoaiPhong = phong.LoaiPhong;
            }
            foreach (var item in listNguoi)
            {
                var nguoi = await _context.Nguoi.FindAsync(item.Id);
                if (nguoi != null)
                {
                    var nguoiPhong = new NguoiVM();
                    nguoiPhong.Id = nguoi.Id;
                    nguoiPhong.HoTen = nguoi.HoTen;
                    nguoiPhong.IsNam = nguoi.IsNam;
                    nguoiPhong.NamSinh = nguoi.NamSinh;
                    nguoiPhong.NoiDangKyHoKhau = nguoi.NoiDangKyHoKhau;
                    nguoiPhong.CCCD = nguoi.CCCD;
                    nguoiPhong.DangO = nguoi.DangO;
                    nguoiPhong.NgayDi = nguoi.NgayDi;
                    nguoiPhong.PhongId = id;
                    phongVM.DanhSachNguoi.Add(nguoiPhong);
                }
            }

            var listHoaDon = await _context.HoaDonPhong
                .Where(c => c.Phong.Id == id)
                .ToListAsync();

            foreach (var item in listHoaDon)
            {
                var hoadon = await _context.HoaDonPhong.FindAsync(item.Id);
                if (hoadon != null)
                {
                    var hoadonPhong = new HoaDonPhongVM();
                    hoadonPhong.Id = hoadon.Id;
                    hoadonPhong.NgayHoaDon = hoadon.NgayHoaDon;
                    hoadonPhong.SoDienThangTruoc = hoadon.SoDienThangTruoc;
                    hoadonPhong.SoDienThangNay = hoadon.SoDienThangNay;
                    hoadonPhong.TongSoDien = hoadon.TongSoDien;
                    hoadonPhong.TongGiaDien = hoadon.TongGiaDien;

                    hoadonPhong.SoNuocThangTruoc = hoadon.SoNuocThangTruoc;
                    hoadonPhong.SoNuocThangNay = hoadon.SoNuocThangNay;
                    hoadonPhong.TongSoNuoc = hoadon.TongSoNuoc;
                    hoadonPhong.TongGiaNuoc = hoadon.TongGiaNuoc;

                    hoadonPhong.SoNgayO = hoadon.SoNgayO;
                    hoadonPhong.TongTienPhong = hoadon.TongTienPhong;
                    hoadonPhong.TongHoaDon = hoadon.TongHoaDon;
                    hoadonPhong.GhiChu = hoadon.GhiChu;

                    phongVM.DanhSachHoaDon.Add(hoadonPhong);
                }
            }

            return phongVM;
        }
        public async Task<Phong> Add(string tenPhong, int loaiPhong)
        {
            var phong = new Phong
            {
                TenPhong = tenPhong,
                LoaiPhong = loaiPhong,
                DanhSachNguoi = null,
                DanhSachHoaDon = null,
            };

            _context.Phong.Add(phong);

            await _context.SaveChangesAsync();

            return phong;
        }
        public async Task<Phong> Delete(int id)
        {
            var phong = await _context.Phong.FindAsync(id);

            if (phong == null)
            {
                throw new KeyNotFoundException(id.ToString());
            }

            _context.Remove(phong);

            await _context.SaveChangesAsync();

            return phong;
        }
        public async Task<Phong> Update(int id, string tenPhong, int loaiPhong)
        {
            var phong = await _context.Phong.FindAsync(id);

            if (phong == null)
            {
                throw new KeyNotFoundException();
            }

            phong.TenPhong = tenPhong;
            phong.LoaiPhong = loaiPhong;

            _context.Phong.Update(phong);
            await _context.SaveChangesAsync();

            return phong;
        }
    }
}
