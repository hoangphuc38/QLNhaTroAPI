using Microsoft.EntityFrameworkCore;
using QLNhaTroAPI.Data;
using QLNhaTroAPI.Models;
using QLNhaTroAPI.Repositories;

namespace QLNhaTroAPI.Services
{
    public class BangGiaRepo : IBangGiaRepo
    {
        private readonly DataContext _context;
        public BangGiaRepo(DataContext context)
        {
            _context = context;
        }
        public async Task<List<BangGia>> GetBangGia(string UserId)
        {
            var banggia = await _context.BangGia.Where(c => c.UserId == UserId).ToListAsync();

            if (banggia == null)
            {
                throw new KeyNotFoundException();
            }

            return banggia;
        }
        public async Task<BangGia> AddItemBangGia(string UserId, BangGia bangGia)
        {
            var banggia = new BangGia
            {
                UserId = UserId,
                HangMuc = bangGia.HangMuc,
                DonVi = bangGia.DonVi,
                Gia = bangGia.Gia,
            };

            _context.BangGia.Add(banggia);

            await _context.SaveChangesAsync();

            return banggia;
        }
        public async Task<BangGia> Update(string UserId, int id, BangGia banggiaVM)
        {
            var banggia = await _context.BangGia.FindAsync(id);

            if (banggia == null)
            {
                throw new KeyNotFoundException();
            }

            banggia.UserId = UserId;
            banggia.HangMuc = banggiaVM.HangMuc;
            banggia.Gia = banggiaVM.Gia;
            banggia.DonVi = banggiaVM.DonVi;

            _context.BangGia.Update(banggia);
            await _context.SaveChangesAsync();

            return banggia;
        }
    }
}
