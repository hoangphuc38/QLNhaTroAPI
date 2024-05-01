using QLNhaTroAPI.Models;

namespace QLNhaTroAPI.Repositories
{
    public interface IBangGiaRepo
    {
        Task<List<BangGia>> GetBangGia(string UserId);
        Task<BangGia> AddItemBangGia(string UserId, BangGia bangGia);
        Task<BangGia> Update(string UserId, int id, BangGia bangGia);

    }
}
