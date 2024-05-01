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
        public async Task<HoaDonPhong> Add(string UserId, HoaDonPhongVM hoadonVM)
        {
            var tongket = await _context.TongKetThang
                .Where(c => c.NgayTongKet.Month == DateTime.Now.Month
                    && c.NgayTongKet.Year == DateTime.Now.Year & c.UserId == UserId)
                .FirstOrDefaultAsync();

            if (tongket == null)
            {
                _context.Database.ExecuteSqlRaw(
                    $"INSERT INTO TongKetThang (NgayTongKet, TongDien, TongNuoc, TongTienTongKet, UserId)" +
                    $"VALUES ('{DateTime.Now}', 0, 0, 0, '" + UserId + "')"
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
                .Where(c => c.NgayTongKet.Month == DateTime.Now.Month
                    && c.NgayTongKet.Year == DateTime.Now.Year && c.UserId == UserId)
                .FirstOrDefaultAsync();

            if (tongket_after == null)
            {
                throw new KeyNotFoundException();
            }

            hoadonVM.TongKetId = tongket_after.Id;

            var tongketThang = _context.TongKetThang.Where(c => c.Id == hoadonVM.TongKetId).FirstOrDefault();
            hoadon.TongKet = tongketThang;
           
            _context.Database.ExecuteSqlRaw(
                $"UPDATE TongKetThang " +
                $"SET TongDien = TongDien + {hoadonVM.TongGiaDien}, " +
                $"TongNuoc = TongNuoc + {hoadonVM.TongGiaNuoc}, " +
                $"TongTienTongKet = TongTienTongKet + {hoadonVM.TongHoaDon}" +
                $" WHERE " + "UserId = '" + UserId + "' AND " +
                $"(SELECT MONTH(NgayTongKet) as Month) = {DateTime.Now.Month} AND " +
                $"(SELECT YEAR(NgayTongKet) as Year) = {DateTime.Now.Year} "
            );

            _context.HoaDonPhong.Add(hoadon);

            await _context.SaveChangesAsync();

            return hoadon;
        }
        public async Task<HoaDonPhong> Update(string UserId, int Id, HoaDonPhongVM hoadonVM)
        {
            var hoadon = await _context.HoaDonPhong.FindAsync(Id);

            if (hoadon == null)
            {
                throw new KeyNotFoundException();
            }

            double TongGiaDienTruoc = hoadon.TongGiaDien;
            double TongGiaNuocTruoc = hoadon.TongGiaNuoc;
            double TongHoaDonTruoc = hoadon.TongHoaDon;

            hoadon.NgayHoaDon = DateTime.Now;
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
                .Where(c => c.NgayTongKet.Month == DateTime.Now.Month
                    && c.NgayTongKet.Year == DateTime.Now.Year && c.UserId == UserId)
                .FirstOrDefaultAsync();

            if (tongket_after == null)
            {
                throw new KeyNotFoundException();
            }

            tongket_after.UserId = UserId;
            tongket_after.NgayTongKet = DateTime.Now;
            tongket_after.TongNuoc = tongket_after.TongNuoc - TongGiaNuocTruoc + hoadonVM.TongGiaNuoc;
            tongket_after.TongDien = tongket_after.TongDien - TongGiaDienTruoc + hoadonVM.TongGiaDien;
            tongket_after.TongTienTongKet = tongket_after.TongTienTongKet - TongHoaDonTruoc + hoadonVM.TongHoaDon;

            _context.TongKetThang.Update(tongket_after);

            hoadonVM.TongKetId = tongket_after.Id;

            hoadon.TongKet = tongket_after;

            _context.HoaDonPhong.Update(hoadon);         

            await _context.SaveChangesAsync();

            return hoadon;
        }
        public async Task<HoaDonPhong> Delete(int Id)
        {
            var hoadonphong = await _context.HoaDonPhong.FindAsync(Id);

            if (hoadonphong == null)
            {
                throw new KeyNotFoundException(Id.ToString());
            }

            _context.Remove(hoadonphong);

            await _context.SaveChangesAsync();

            return hoadonphong;
        }
    }
}
