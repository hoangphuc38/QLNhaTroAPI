using Microsoft.AspNetCore.Mvc;
using QLNhaTroAPI.Models;
using QLNhaTroAPI.Repositories;

namespace QLNhaTroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BangGiaController : ControllerBase
    {
        private readonly IBangGiaRepo _repo;
        public BangGiaController(IBangGiaRepo repo)
        {
            _repo = repo;
        }
        [HttpGet("get-bang-gia")]
        public async Task<IActionResult> GetBangGia()
        {
            return Ok(await _repo.GetBangGia());
        }

        [HttpPut("update-bang-gia")]
        public async Task<IActionResult> Update(int id, BangGia banggia)
        {
            return Ok(await _repo.Update(id, banggia));
        }
    }
}
