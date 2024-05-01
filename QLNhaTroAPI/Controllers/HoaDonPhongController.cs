using Microsoft.AspNetCore.Mvc;
using QLNhaTroAPI.Repositories;
using QLNhaTroAPI.ViewModels;

namespace QLNhaTroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonPhongController : ControllerBase
    {
        private readonly IHoaDonPhongRepo _repo;
        public HoaDonPhongController(IHoaDonPhongRepo repo)
        {
            _repo = repo;
        }
        [HttpGet("get-hoadon/{phongId}/{month}/{year}")]
        public async Task<IActionResult> GetHoaDonPhong(int month, int year, int phongId)
        {
            return Ok(await _repo.GetHoaDonPhong(month, year, phongId));
        }

        [HttpPost("new-hoadon")]
        public async Task<IActionResult> AddHoaDonPhong(string UserId, [FromBody] HoaDonPhongVM hoadonVM)
        {
            return Ok(await _repo.Add(UserId, hoadonVM));
        }

        [HttpPut("update-hoadon/{Id}")]
        public async Task<IActionResult> UpdateHoaDonPhong(string UserId, int Id, HoaDonPhongVM hoadonVM)
        {
            return Ok(await _repo.Update(UserId, Id, hoadonVM));
        }

        [HttpDelete("delete-hoadon")]
        public async Task<IActionResult> DeleteHoaDonPhong(int Id)
        {
            return Ok(await _repo.Delete(Id));
        }
        
    }
}
