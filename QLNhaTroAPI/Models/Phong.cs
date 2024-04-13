using QLNhaTroAPI.ViewModels;

namespace QLNhaTroAPI.Models
{
    public class Phong
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string? TenPhong { get; set; }
        public int LoaiPhong { get; set; }
        public double GiaPhong { get; set; }
        public List<NguoiVM>? DanhSachNguoi { get; set; }
        public List<HoaDonPhongVM>? DanhSachHoaDon { get; set; }
    }
}
