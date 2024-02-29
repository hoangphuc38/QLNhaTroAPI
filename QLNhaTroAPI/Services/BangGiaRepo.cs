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
        public async Task<List<BangGia>> GetBangGia()
        {
            var banggia = await _context.BangGia.ToListAsync();

            if (banggia == null)
            {
                throw new KeyNotFoundException();
            }

            return banggia;
        }
        public async Task<BangGia> Update(int id, BangGia banggiaVM)
        {
            var banggia = await _context.BangGia.FindAsync(id);

            if (banggia == null)
            {
                throw new KeyNotFoundException();
            }

            banggia.HangMuc = banggiaVM.HangMuc;
            banggia.Gia = banggiaVM.Gia;
            banggia.DonVi = banggiaVM.DonVi;

            _context.BangGia.Update(banggia);
            await _context.SaveChangesAsync();

            return banggia;
        }
    }
}
