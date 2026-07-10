using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptManagement.Service.DTO
{
    public class ChiTietKhoanVayDTO
    {
        public int Id { get; set; }

        public int KhoanNoId { get; set; }

        public DateOnly NgayVay { get; set; }

        public decimal SoTienVay { get; set; }

        public decimal SoTienLai { get; set; }

        public decimal? SoTienTraMoiThang { get; set; }

        public int? NgayDenHan { get; set; }

        public decimal? TongTien { get; set; }
    }
    public class TongKhoanVayDTO
    {
        public decimal TongTienVay { get; set; }
        public decimal TongTienLai { get; set; }
        public decimal TongTienPhaiTra { get; set; }
    }
}
