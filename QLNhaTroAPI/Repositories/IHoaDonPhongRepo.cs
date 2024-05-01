using QLNhaTroAPI.Models;
using QLNhaTroAPI.ViewModels;

namespace QLNhaTroAPI.Repositories
{
    public interface IHoaDonPhongRepo
    {
        Task<HoaDonPhong> GetHoaDonPhong(int month, int year, int phongId);
        Task<HoaDonPhong> Add(string UserId, HoaDonPhongVM hoadonVM);
        Task<HoaDonPhong> Update(string UserId, int Id, HoaDonPhongVM hoadonVM);
        Task<HoaDonPhong> Delete(int Id);
    }
}
