using QLNhaTroAPI.Models;

namespace QLNhaTroAPI.Repositories
{
    public interface IPhongRepo
    {
        Task<List<Phong>> GetAll();
        Task<Phong> GetDetailPhong(int id);
        Task<Phong> Add(string tenPhong, int loaiPhong);
    }
}
