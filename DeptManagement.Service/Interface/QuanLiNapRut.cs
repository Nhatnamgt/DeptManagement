using DeptManagement.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptManagement.Service.Interface
{
    public interface QuanLiNapRut
    {
        Task<List<GetQuanLiNapRutDTO>> GetAllAsync();
        Task<CreateEditQuanLiNapRutDTO> CreateAsync(CreateEditQuanLiNapRutDTO dto);
        Task<CreateEditQuanLiNapRutDTO> UpdateAsync(CreateEditQuanLiNapRutDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
