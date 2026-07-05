using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptManagement.Service.DTO
{
    public class GetQuanLiNapRutDTO
    {
        public int Id { get; set; }

        public DateOnly? NgayNap { get; set; }

        public decimal SoTienNap { get; set; }

        public DateOnly? NgayRut { get; set; }

        public decimal SoTienRut { get; set; }

        public decimal? LaiLo { get; set; }
    }
    public class CreateEditQuanLiNapRutDTO
    {
        public int Id { get; set; }

        public DateOnly? NgayNap { get; set; }

        public decimal SoTienNap { get; set; }

        public DateOnly? NgayRut { get; set; }

        public decimal SoTienRut { get; set; }

        public decimal? LaiLo { get; set; }
    }

}
