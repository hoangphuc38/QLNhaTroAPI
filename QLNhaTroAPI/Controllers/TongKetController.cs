using Microsoft.AspNetCore.Mvc;
using QLNhaTroAPI.Repositories;

namespace QLNhaTroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TongKetController : ControllerBase
    {
        private readonly ITongKetRepo _repo;
        public TongKetController(ITongKetRepo repo)
        {
            _repo = repo;
        }
        [HttpGet("get-tongketthang/{month}/{year}")]
        public async Task<IActionResult> GetTongKetThang(string UserId, int month, int year)
        {
            return Ok(await _repo.GetTongKetThang(UserId, month, year));
        }
    }
}
