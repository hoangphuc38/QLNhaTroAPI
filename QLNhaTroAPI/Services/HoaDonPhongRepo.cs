using Microsoft.EntityFrameworkCore;
using QLNhaTroAPI.Data;
using QLNhaTroAPI.Models;
using QLNhaTroAPI.Repositories;
using QLNhaTroAPI.ViewModels;

namespace QLNhaTroAPI.Services
{
    public class HoaDonPhongRepo : IHoaDonPhongRepo
    {
        private readonly DataContext _context;
        public HoaDonPhongRepo(DataContext context)
        {
            _context = context;
        }
        public async Task<HoaDonPhong> GetHoaDonPhong(int month, int year, int phongId)
        {
            var hoadon = await _context.HoaDonPhong
                .Where(c => c.NgayHoaDon.Month == month && c.NgayHoaDon.Year == year && c.Phong.Id == phongId)
                .FirstOrDefaultAsync();

            if (hoadon == null)
            {
                throw new KeyNotFoundException();
            }

            return hoadon;
        }
        public async Task<HoaDonPhong> Add(HoaDonPhongVM hoadonVM)
        {
            var tongket = await _context.TongKetThang
                .Where(c => c.NgayTongKet.Month == hoadonVM.NgayHoaDon.Month
                    && c.NgayTongKet.Year == hoadonVM.NgayHoaDon.Year)
                .FirstOrDefaultAsync();

            if (tongket == null)
            {
                _context.Database.ExecuteSqlRaw(
                    $"INSERT INTO TongKetThang (NgayTongKet, TongDien, TongNuoc, TongTienTongKet)" +
                    $"VALUES ('{DateTime.Now}', 0, 0, 0)"
                );
            }

            var hoadon = new HoaDonPhong
            {
                NgayHoaDon = DateTime.Now,
                SoDienThangTruoc = hoadonVM.SoDienThangTruoc,
                SoDienThangNay = hoadonVM.SoDienThangNay,
                TongSoDien = hoadonVM.TongSoDien,
                TongGiaDien = hoadonVM.TongGiaDien,

                SoNuocThangTruoc = hoadonVM.SoNuocThangTruoc,
                SoNuocThangNay = hoadonVM.SoNuocThangNay,
                TongSoNuoc = hoadonVM.TongSoNuoc,
                TongGiaNuoc = hoadonVM.TongGiaNuoc,

                SoNgayO = hoadonVM.SoNgayO,
                TongTienPhong = hoadonVM.TongTienPhong,

                TongHoaDon = hoadonVM.TongHoaDon,
                GhiChu = hoadonVM.GhiChu,
            };

            var phong = _context.Phong.Where(c => c.Id == hoadonVM.PhongId).FirstOrDefault();
            hoadon.Phong = phong;

            var tongket_after = await _context.TongKetThang
                .Where(c => c.NgayTongKet.Month == hoadonVM.NgayHoaDon.Month
                    && c.NgayTongKet.Year == hoadonVM.NgayHoaDon.Year)
                .FirstOrDefaultAsync();

            if (tongket_after == null)
            {
                throw new KeyNotFoundException();
            }

            hoadonVM.TongKetId = tongket_after.Id;

            var tongketThang = _context.TongKetThang.Where(c => c.Id == hoadonVM.TongKetId).FirstOrDefault();
            hoadon.TongKet = tongketThang;

            _context.HoaDonPhong.Add(hoadon);

            await _context.SaveChangesAsync();

            _context.Database.ExecuteSqlRaw(
                $"UPDATE TongKetThang " +
                $"SET TongDien = TongDien + {hoadonVM.TongGiaDien}, " +
                $"TongNuoc = TongNuoc + {hoadonVM.TongGiaNuoc}, " +
                $"TongTienTongKet = TongTienTongKet + {hoadonVM.TongHoaDon}" +
                $" WHERE " +
                $"(SELECT MONTH(NgayTongKet) as Month) = {DateTime.Now.Month} AND " +
                $"(SELECT YEAR(NgayTongKet) as Year) = {DateTime.Now.Year} "
            );

            return hoadon;
        }
        public async Task<HoaDonPhong> Update(HoaDonPhongVM hoadonVM)
        {
            var hoadon = await _context.HoaDonPhong.FindAsync(hoadonVM.Id);

            if (hoadon == null)
            {
                throw new KeyNotFoundException();
            }

            _context.Database.ExecuteSqlRaw(
                $"UPDATE TongKetThang " +
                $"SET TongDien = TongDien - {hoadon.TongGiaDien} + {hoadonVM.TongGiaDien}, " +
                $"TongNuoc = TongNuoc - {hoadon.TongGiaNuoc} + {hoadonVM.TongGiaNuoc}, " +
                $"TongTienTongKet = TongTienTongKet - {hoadon.TongHoaDon} + {hoadonVM.TongHoaDon}" +
                $" WHERE " +
                $"(SELECT MONTH(NgayTongKet) as Month) = {hoadonVM.NgayHoaDon.Month} AND " +
                $"(SELECT YEAR(NgayTongKet) as Year) = {hoadonVM.NgayHoaDon.Year} "
            );

            hoadon.NgayHoaDon = hoadonVM.NgayHoaDon;
            hoadon.SoDienThangTruoc = hoadonVM.SoDienThangTruoc;
            hoadon.SoDienThangNay = hoadonVM.SoDienThangNay;
            hoadon.TongSoDien = hoadonVM.TongSoDien;
            hoadon.TongGiaDien = hoadonVM.TongGiaDien;

            hoadon.SoNuocThangTruoc = hoadonVM.SoNuocThangTruoc;
            hoadon.SoNuocThangNay = hoadonVM.SoNuocThangNay;
            hoadon.TongSoNuoc = hoadonVM.TongSoNuoc;
            hoadon.TongGiaNuoc = hoadonVM.TongGiaNuoc;

            hoadon.SoNgayO = hoadonVM.SoNgayO;
            hoadon.TongTienPhong = hoadonVM.TongTienPhong;

            hoadon.TongHoaDon = hoadonVM.TongHoaDon;
            hoadon.GhiChu = hoadonVM.GhiChu;

            var phong = _context.Phong.Where(c => c.Id == hoadonVM.PhongId).FirstOrDefault();
            hoadon.Phong = phong;

            var tongket_after = await _context.TongKetThang
                .Where(c => c.NgayTongKet.Month == hoadonVM.NgayHoaDon.Month
                    && c.NgayTongKet.Year == hoadonVM.NgayHoaDon.Year)
                .FirstOrDefaultAsync();

            if (tongket_after == null)
            {
                throw new KeyNotFoundException();
            }

            hoadonVM.TongKetId = tongket_after.Id;

            var tongketThang = _context.TongKetThang.Where(c => c.Id == hoadonVM.TongKetId).FirstOrDefault();
            hoadon.TongKet = tongketThang;

            _context.HoaDonPhong.Update(hoadon);

            await _context.SaveChangesAsync();

            return hoadon;
        }
    }
}
