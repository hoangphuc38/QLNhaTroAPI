using QLNhaTroAPI.Models;

namespace QLNhaTroAPI.ViewModels
{
    public class HoaDonInTongKet
    {
        public int Id { get; set; }
        public DateTime NgayHoaDon { get; set; }
        public double? SoDienThangTruoc { get; set; }
        public double? SoDienThangNay { get; set; }
        public double? TongSoDien { get; set; }
        public double? TongGiaDien { get; set; }
        public double? SoNuocThangTruoc { get; set; }
        public double? SoNuocThangNay { get; set; }
        public double? TongSoNuoc { get; set; }
        public double? TongGiaNuoc { get; set; }
        public double? SoNgayO { get; set; }
        public double? TongTienPhong { get; set; }
        public double? TongHoaDon { get; set; }
        public string? GhiChu { get; set; }

        public Phong? Phong { get; set; }
    }
}
