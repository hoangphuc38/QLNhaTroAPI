using QLNhaTroAPI.Models;
using QLNhaTroAPI.ViewModels;

namespace QLNhaTroAPI.Repositories
{
    public interface IPhongRepo
    {
        Task<List<Phong>> GetAll();
        Task<Phong> GetDetailPhong(int id);
        Task<Phong> Add(string tenPhong, int loaiPhong);
        Task<Phong> Delete(int id);
        Task<Phong> Update(int id, string tenPhong, int loaiPhong);
    }
}
