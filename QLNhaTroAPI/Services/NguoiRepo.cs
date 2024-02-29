using Microsoft.EntityFrameworkCore;
using QLNhaTroAPI.Data;
using QLNhaTroAPI.Models;
using QLNhaTroAPI.Repositories;
using QLNhaTroAPI.ViewModels;

namespace QLNhaTroAPI.Services
{
    public class NguoiRepo : INguoiRepo
    {
        private readonly DataContext _context;
        public NguoiRepo(DataContext context)
        {
            _context = context;
        }
        public async Task<Nguoi> GetInfoNguoi(int id)
        {
            var nguoi = await _context.Nguoi.FindAsync(id);

            if (nguoi == null)
            {
                throw new KeyNotFoundException(id.ToString());
            }

            return nguoi;
        }
        public async Task<List<Nguoi>> GetNguoiFromPhong(int phongId)
        {
            var listNguoi = await _context.Nguoi
                .Where(c => c.Phong.Id == phongId)
                .ToListAsync();

            if (listNguoi == null)
            {
                throw new KeyNotFoundException(phongId.ToString());
            }

            return listNguoi;
        }
        public async Task<Nguoi> Add(NguoiVM nguoiVM)
        {
            var nguoi = new Nguoi
            {
                Avatar = nguoiVM.Avatar,
                HoTen = nguoiVM.HoTen,
                NamSinh = nguoiVM.NamSinh,
                IsNam = nguoiVM.IsNam,
                NoiDangKyHoKhau = nguoiVM.NoiDangKyHoKhau,
                CCCD = nguoiVM.CCCD,
                NgheNghiep = nguoiVM.NgheNghiep,
                DangO = true,
                NgayDi = null,
            };

            var phong = _context.Phong.Where(c => c.Id == nguoiVM.PhongId).FirstOrDefault();

            nguoi.Phong = phong;

            _context.Nguoi.Add(nguoi);

            await _context.SaveChangesAsync();

            return nguoi;
        }
        public async Task<Nguoi> Update(NguoiVM nguoiVM)
        {
            var nguoi = await _context.Nguoi.FindAsync(nguoiVM.Id);

            if (nguoi == null)
            {
                throw new KeyNotFoundException();
            }

            nguoi.Avatar = nguoiVM.Avatar;
            nguoi.HoTen = nguoiVM.HoTen;
            nguoi.NamSinh = nguoiVM.NamSinh;
            nguoi.IsNam = nguoiVM.IsNam;
            nguoi.NoiDangKyHoKhau = nguoiVM.NoiDangKyHoKhau;
            nguoi.CCCD = nguoiVM.CCCD;
            nguoi.NgheNghiep = nguoi.NgheNghiep;
            nguoi.DangO = nguoiVM.DangO;
            nguoi.NgayDi = nguoiVM.NgayDi;

            var phong = await _context.Phong.FindAsync(nguoiVM.PhongId);
            nguoi.Phong = phong;

            _context.Nguoi.Update(nguoi);
            await _context.SaveChangesAsync();

            return nguoi;
        }
        public async Task<Nguoi> Delete(int id)
        {
            var nguoi = await _context.Nguoi.FindAsync(id);

            if (nguoi == null)
            {
                throw new KeyNotFoundException(id.ToString());
            }

            _context.Remove(nguoi);

            await _context.SaveChangesAsync();

            return nguoi;
        }
    }
}
