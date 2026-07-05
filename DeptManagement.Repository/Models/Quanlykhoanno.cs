using System;
using System.Collections.Generic;

namespace DeptManagement.Repository.Models;

public partial class Quanlykhoanno
{
    public int Id { get; set; }

    public string Tenkhoanno { get; set; } = null!;

    public string? Nguoichovay { get; set; }

    public string? Ghichu { get; set; }

    public virtual ICollection<Chitietkhoanvay> Chitietkhoanvays { get; set; } = new List<Chitietkhoanvay>();
}
