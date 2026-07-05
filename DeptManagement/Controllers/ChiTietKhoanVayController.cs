using DeptManagement.Service.DTO;
using DeptManagement.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DeptManagement.Controllers
{ 
        [Route("api/[controller]")]
        [ApiController]
        public class ChiTietKhoanVayController : ControllerBase
        {
            private readonly ChiTietKhoanVays _service;

            public ChiTietKhoanVayController(ChiTietKhoanVays service)
            {
                _service = service;
            }

            // GET: api/ChiTietKhoanVay
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var result = await _service.GetAllAsync();
                return Ok(result);
            }

            // GET: api/ChiTietKhoanVay/KhoanNo/1
            [HttpGet("KhoanNo/{khoanNoId}")]
            public async Task<IActionResult> GetByKhoanNoId(int khoanNoId)
            {
                var result = await _service.GetByKhoanNoIdAsync(khoanNoId);
                return Ok(result);
            }

            // GET: api/ChiTietKhoanVay/ThongKe/1
            [HttpGet("ThongKe/{khoanNoId}")]
            public async Task<IActionResult> GetTongTienByKhoanNoId(int khoanNoId)
            {
                var result = await _service.GetTongTienByKhoanNoIdAsync(khoanNoId);
                return Ok(result);
            }

            // POST: api/ChiTietKhoanVay
            [HttpPost]
            public async Task<IActionResult> Create([FromBody] ChiTietKhoanVayDTO dto)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _service.CreateAsync(dto);
                return Ok(result);
            }

            // PUT: api/ChiTietKhoanVay
            [HttpPut]
            public async Task<IActionResult> Update([FromBody] ChiTietKhoanVayDTO dto)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _service.UpdateAsync(dto);
                return Ok(result);
            }

            // DELETE: api/ChiTietKhoanVay/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var result = await _service.DeleteAsync(id);

                if (!result)
                    return NotFound("Không tìm thấy chi tiết khoản vay.");

                return Ok("Xóa thành công.");
            }
        }
}

