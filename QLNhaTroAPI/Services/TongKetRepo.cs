using Microsoft.EntityFrameworkCore;
using QLNhaTroAPI.Data;
using QLNhaTroAPI.Models;
using QLNhaTroAPI.Repositories;
using QLNhaTroAPI.ViewModels;

namespace QLNhaTroAPI.Services
{
    public class TongKetRepo : ITongKetRepo
    {
        private readonly DataContext _context;
        public TongKetRepo(DataContext context)
        {
            _context = context;
        }
        public async Task<TongKet> GetTongKetThang(int month, int year)
        {
            TongKet tongketVM = new TongKet();
            tongketVM.DanhSachHoaDon = new List<HoaDonInTongKet>();

            var tongket = await _context.TongKetThang
                .Where(c => c.NgayTongKet.Month == month && c.NgayTongKet.Year == year)
                .FirstOrDefaultAsync();

            if (tongket == null)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                tongketVM.Id = tongket.Id;
                tongketVM.NgayTongKet = tongket.NgayTongKet;
                tongketVM.TongNuoc = tongket.TongNuoc;
                tongketVM.TongDien = tongket.TongDien;
                tongketVM.TongTienTongKet = tongket.TongTienTongKet;
            }

            var listHoaDon = await _context.HoaDonPhong
                .Where(c => c.TongKet.Id == tongket.Id)
                .OrderBy(c => c.PhongId)
                .ToListAsync();

            foreach (var item in listHoaDon)
            {
                var hoadon = await _context.HoaDonPhong.FindAsync(item.Id);

                var phong = await _context.Phong.FindAsync(item.PhongId);

                if (hoadon != null)
                {
                    var hoadonPhong = new HoaDonInTongKet();
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

                    hoadonPhong.Phong = phong;

                    tongketVM.DanhSachHoaDon.Add(hoadonPhong);
                }
            }

            return tongketVM;
        }
    }
}
