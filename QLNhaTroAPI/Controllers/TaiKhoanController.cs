using Microsoft.AspNetCore.Mvc;
using QLNhaTroAPI.Repositories;
using QLNhaTroAPI.ViewModels;

namespace QLNhaTroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly ITaiKhoanRepo _repo;
        public TaiKhoanController(ITaiKhoanRepo repo)
        {
            _repo = repo;
        }
        [HttpPost("dang-ky")]
        public async Task<IActionResult> DangKy([FromBody] TaiKhoanVM register)
        {
            return Ok(await _repo.DangKy(register));
        }
        [HttpPost("dang-nhap")]
        public async Task<IActionResult> DangNhap([FromBody] DangNhapVM login)
        {
            return Ok(await _repo.DangNhap(login));
        }
        
    }
}
