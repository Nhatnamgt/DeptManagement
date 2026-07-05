using System;
using System.Collections.Generic;

namespace DeptManagement.Repository.Models;

public partial class Chitietkhoanvay
{
    public int Id { get; set; }

    public int Khoannoid { get; set; }

    public DateOnly Ngayvay { get; set; }

    public decimal Sotienvay { get; set; }

    public decimal Sotienlai { get; set; }

    public decimal? Sotientramoiky { get; set; }

    public int? Songaytra { get; set; }

    public decimal? Tongtien { get; set; }

    public virtual Quanlykhoanno Khoanno { get; set; } = null!;
}
