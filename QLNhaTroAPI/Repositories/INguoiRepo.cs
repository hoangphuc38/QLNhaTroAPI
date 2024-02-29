using QLNhaTroAPI.Models;
using QLNhaTroAPI.ViewModels;

namespace QLNhaTroAPI.Repositories
{
    public interface INguoiRepo
    {
        Task<Nguoi> GetInfoNguoi(int id);
        Task<List<Nguoi>> GetNguoiFromPhong(int phongId);
        Task<Nguoi> Add(NguoiVM nguoi);
        Task<Nguoi> Update(NguoiVM nguoi);
        Task<Nguoi> Delete(int id);
    }
}
