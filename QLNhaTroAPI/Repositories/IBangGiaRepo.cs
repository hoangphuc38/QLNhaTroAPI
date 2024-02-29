using QLNhaTroAPI.Models;

namespace QLNhaTroAPI.Repositories
{
    public interface IBangGiaRepo
    {
        Task<List<BangGia>> GetBangGia();
        Task<BangGia> Update(int id, BangGia bangGia);
    }
}
