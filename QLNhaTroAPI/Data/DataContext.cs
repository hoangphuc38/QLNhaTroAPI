using Microsoft.EntityFrameworkCore;
using QLNhaTroAPI.Models;

namespace QLNhaTroAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Phong> Phong { get; set; }
        public DbSet<Nguoi> Nguoi { get; set; }
        public DbSet<HoaDonPhong> HoaDonPhong { get; set; }
        public DbSet<BangGia> BangGia { get; set; }
        public DbSet<TongKet> TongKetThang { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
