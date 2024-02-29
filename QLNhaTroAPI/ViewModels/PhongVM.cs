using QLNhaTroAPI.Models;

namespace QLNhaTroAPI.ViewModels
{
    public class PhongVM
    {
        public int Id { get; set; }
        public string? TenPhong { get; set; }
        public int LoaiPhong { get; set; }
        public List<Nguoi>? DanhSachNguoi { get; set; }
        public List<HoaDonPhong>? DanhSachHoaDon { get; set; }
    }
}
