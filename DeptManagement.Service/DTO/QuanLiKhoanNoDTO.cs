using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptManagement.Service.DTO
{
    public class QuanLiKhoanNoDTO
    {
        public int Id { get; set; }
        public string TenKhoanNo { get; set; } = null!;

        public string? GhiChu { get; set; }
    }

    public class UpdateQuanLiKhoanNoDTO
    {
        public int Id { get; set; }

        public string TenKhoanNo { get; set; } = null!;

        public string? GhiChu { get; set; }
    }
}
