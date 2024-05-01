using QLNhaTroAPI.Models;
using QLNhaTroAPI.ViewModels;

namespace QLNhaTroAPI.Repositories
{
    public interface ITaiKhoanRepo
    {
        Task<TaiKhoan> DangKy(TaiKhoanVM request);
        Task<TaiKhoanResponse> DangNhap(DangNhapVM login);
    }
}
