using DeptManagement.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptManagement.Service.Interface
{
    public interface ChiTietKhoanVays
    {
        Task<List<ChiTietKhoanVayDTO>> GetByKhoanNoIdAsync(int khoanNoId);
        Task<TongKhoanVayDTO> GetTongTienByKhoanNoIdAsync(int khoanNoId);
        Task<List<ChiTietKhoanVayDTO>> GetAllAsync();
        Task<ChiTietKhoanVayDTO> CreateAsync(ChiTietKhoanVayDTO dto);
        Task<ChiTietKhoanVayDTO> UpdateAsync(ChiTietKhoanVayDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
