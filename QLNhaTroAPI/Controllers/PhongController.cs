using Microsoft.AspNetCore.Mvc;
using QLNhaTroAPI.Repositories;

namespace QLNhaTroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhongController : ControllerBase
    {
        private readonly IPhongRepo _repo;
        public PhongController(IPhongRepo repo)
        {
            _repo = repo;
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllPhong()
        {
            return Ok(await _repo.GetAll());
        }

        [HttpGet("get-detail/{roomId}")]
        public async Task<IActionResult> GetPhongById(int roomId)
        {
            return Ok(await _repo.GetDetailPhong(roomId));
        }

        [HttpPost("new-phong")]
        public async Task<IActionResult> Add(string tenPhong, int loaiPhong)
        {
            return Ok(await _repo.Add(tenPhong, loaiPhong));
        }
    }
}
