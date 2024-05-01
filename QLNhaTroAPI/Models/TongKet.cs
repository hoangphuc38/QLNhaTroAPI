using QLNhaTroAPI.ViewModels;

namespace QLNhaTroAPI.Models
{
    public class TongKet
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public DateTime NgayTongKet { get; set; }
        public double TongDien { get; set; }
        public double TongNuoc { get; set; }
        public double TongTienTongKet { get; set; }
        public List<HoaDonInTongKet>? DanhSachHoaDon { get; set; }
    }
}
