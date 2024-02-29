using QLNhaTroAPI.Models;
using QLNhaTroAPI.ViewModels;

namespace QLNhaTroAPI.Repositories
{
    public interface IHoaDonPhongRepo
    {
        Task<HoaDonPhong> GetHoaDonPhong(int month, int year, int phongId);
        Task<HoaDonPhong> Add(HoaDonPhongVM hoadonVM);
        Task<HoaDonPhong> Update(HoaDonPhongVM hoadonVM);
    }
}
