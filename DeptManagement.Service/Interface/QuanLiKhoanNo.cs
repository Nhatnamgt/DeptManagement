using DeptManagement.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptManagement.Service.Interface
{
    public interface QuanLiKhoanNo
    {
        Task<List<QuanLiKhoanNoDTO>> GetAllAsync();
        Task<UpdateQuanLiKhoanNoDTO> CreateAsync(UpdateQuanLiKhoanNoDTO dto);
        Task<UpdateQuanLiKhoanNoDTO> UpdateAsync(UpdateQuanLiKhoanNoDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
