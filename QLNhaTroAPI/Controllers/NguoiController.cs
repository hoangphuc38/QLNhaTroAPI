using Microsoft.AspNetCore.Mvc;
using QLNhaTroAPI.Repositories;
using QLNhaTroAPI.ViewModels;

namespace QLNhaTroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiController : ControllerBase
    {
        private readonly INguoiRepo _repo;
        public NguoiController(INguoiRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("get-people-by-id/{id}")]
        public async Task<IActionResult> GetNguoi(int id)
        {
            return Ok(await _repo.GetInfoNguoi(id));
        }

        [HttpGet("get-people-of-room/{roomId}")]
        public async Task<IActionResult> GetNguoiFromPhong(int roomId)
        {
            return Ok(await _repo.GetNguoiFromPhong(roomId));
        }

        [HttpPost("new-person")]
        public async Task<IActionResult> Add([FromBody] NguoiVM nguoi)
        {
            return Ok(await _repo.Add(nguoi));
        }

        [HttpPut("update-person")]
        public async Task<IActionResult> Update([FromBody] NguoiVM nguoi)
        {
            return Ok(await _repo.Update(nguoi));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _repo.Delete(id));
        }
    }
}
