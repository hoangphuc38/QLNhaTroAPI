using System.ComponentModel.DataAnnotations;

namespace QLNhaTroAPI.Models
{
    public class TaiKhoan
    {
        [Key]
        public string UserId { get; set; }
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public string Name { get; set; } = "";
    }
}
