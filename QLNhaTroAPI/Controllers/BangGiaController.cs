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
        public async Task<IActionResult> GetBangGia(string UserId)
        {
            return Ok(await _repo.GetBangGia(UserId));
        }
        [HttpPost("add-bang-gia")]
        public async Task<IActionResult> AddItemBangGia(string UserId, BangGia banggia)
        {
            return Ok(await _repo.AddItemBangGia(UserId, banggia));
        }
        [HttpPut("update-bang-gia")]
        public async Task<IActionResult> Update(string UserId, int id, BangGia banggia)
        {
            return Ok(await _repo.Update(UserId, id, banggia));
        }
    }
}
