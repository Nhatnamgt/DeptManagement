using DeptManagement.Service.DTO;
using DeptManagement.Service.Interface;
using Microsoft.AspNetCore.Mvc;


namespace DeptManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanLiKhoanNoController : ControllerBase
    {
        private readonly QuanLiKhoanNo _service;

        public QuanLiKhoanNoController(QuanLiKhoanNo service)
        {
            _service = service;
        }

        // GET: api/QuanLiKhoanNo
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        // POST: api/QuanLiKhoanNo
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UpdateQuanLiKhoanNoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.CreateAsync(dto);
            return Ok(result);
        }

        // PUT: api/QuanLiKhoanNo
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateQuanLiKhoanNoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.UpdateAsync(dto);
            return Ok(result);
        }

        // DELETE: api/QuanLiKhoanNo/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
                return NotFound("Không tìm thấy khoản nợ.");

            return Ok("Xóa khoản nợ thành công.");
        }
    }
}