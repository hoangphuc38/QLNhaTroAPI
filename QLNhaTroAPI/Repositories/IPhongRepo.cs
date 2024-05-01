using QLNhaTroAPI.Models;
using QLNhaTroAPI.ViewModels;

namespace QLNhaTroAPI.Repositories
{
    public interface IPhongRepo
    {
        Task<List<Phong>> GetAll(string userId);
        Task<Phong> GetDetailPhong(int id);
        Task<Phong> Add(string userID, string tenPhong, int loaiPhong, double giaPhong);
        Task<Phong> Delete(int id);
        Task<Phong> Update(int id, string tenPhong, int loaiPhong, double giaPhong);
    }
}
