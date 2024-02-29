namespace QLNhaTroAPI.ViewModels
{
    public class NguoiVM
    {
        public int Id { get; set; }
        public string? Avatar { get; set; }
        public string? HoTen { get; set; }
        public string? NamSinh { get; set; }
        public Boolean? IsNam { get; set; }
        public string? NoiDangKyHoKhau { get; set; }
        public string? CCCD { get; set; }
        public string? NgheNghiep { get; set; }
        public Boolean? DangO { get; set; }
        public DateTime? NgayDi { get; set; }
        public int PhongId { get; set; }
    }
}
