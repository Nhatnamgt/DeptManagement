using DeptManagement.Service.DTO;
using DeptManagement.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DeptManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanLiNapRutController : ControllerBase
    {
        private readonly QuanLiNapRut _service;

        public QuanLiNapRutController(QuanLiNapRut service)
        {
            _service = service;
        }

        [HttpGet("tong-lai-lo")]
        public async Task<IActionResult> GetTongLaiLo()
        {
            var result = await _service.GetLaiLoAsync();
            return Ok(result);
        }

        // GET: api/QuanLiNapRut
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        // POST: api/QuanLiNapRut
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEditQuanLiNapRutDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.CreateAsync(dto);

            return Ok(result);
        }

        // PUT: api/QuanLiNapRut
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CreateEditQuanLiNapRutDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.UpdateAsync(dto);

            return Ok(result);
        }

        // DELETE: api/QuanLiNapRut/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
                return NotFound("Không tìm thấy giao dịch.");

            return Ok("Xóa thành công.");
        }
    }
}
