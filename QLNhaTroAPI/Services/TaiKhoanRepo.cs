using Microsoft.EntityFrameworkCore;
using QLNhaTroAPI.Data;
using QLNhaTroAPI.Models;
using QLNhaTroAPI.Repositories;
using QLNhaTroAPI.ViewModels;
using System.Text.RegularExpressions;

namespace QLNhaTroAPI.Services
{
    public class TaiKhoanRepo : ITaiKhoanRepo
    {
        private readonly DataContext _context;
        public TaiKhoanRepo(DataContext context)
        {
            _context = context;
        }
        public async Task<TaiKhoan> DangKy(TaiKhoanVM request)
        {
            var taikhoan = new TaiKhoan
            {
                UserId = await AutoID(),
                UserName = request.UserName,
                Password = request.Password,
                Name = request.Name,
            };

            _context.Add(taikhoan);
            
            await _context.SaveChangesAsync();

            return taikhoan;
        }
        public async Task<string> DangNhap(DangNhapVM login)
        {
            var checkUser = await _context.TaiKhoan
                .Where(c => c.UserName == login.UserName && c.Password == login.Password)
                .FirstOrDefaultAsync();

            if (checkUser == null)
            {
                throw new Exception("Không tìm thấy tài khoản");
            }

            return checkUser.UserId;
        }
        private async Task<string> AutoID()
        {
            var ID = "CS0001";

            var maxID = await _context.TaiKhoan
                .OrderByDescending(v => v.UserId)
                .Select(v => v.UserId)
                .FirstOrDefaultAsync();

            if (string.IsNullOrEmpty(maxID))
            {
                return ID;
            }

            var numeric = Regex.Match(maxID, @"\d+").Value;

            if (string.IsNullOrEmpty(numeric))
            {
                return ID;
            }

            ID = "CS";

            numeric = (int.Parse(numeric) + 1).ToString();

            while (ID.Length + numeric.Length < 6)
            {
                ID += '0';
            }

            return ID + numeric;
        }
    }
}
