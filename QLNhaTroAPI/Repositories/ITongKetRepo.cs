using QLNhaTroAPI.Models;
using QLNhaTroAPI.ViewModels;

namespace QLNhaTroAPI.Repositories
{
    public interface ITongKetRepo
    {
        Task<TongKet> GetTongKetThang(string UserId, int month, int year);
    }
}
