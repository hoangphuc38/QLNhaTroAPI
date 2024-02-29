using QLNhaTroAPI.Models;

namespace QLNhaTroAPI.ViewModels
{
    public class TongKetVM
    {
        public int Id { get; set; }
        public DateTime NgayTongKet { get; set; }
        public double TongDien { get; set; }
        public double TongNuoc { get; set; }
        public double TongTienTongKet { get; set; }
        public List<HoaDonInTongKet>? DanhSachHoaDon { get; set; }
    }
}
