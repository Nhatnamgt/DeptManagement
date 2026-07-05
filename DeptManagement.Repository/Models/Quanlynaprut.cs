using System;
using System.Collections.Generic;

namespace DeptManagement.Repository.Models;

public partial class Quanlynaprut
{
    public int Id { get; set; }

    public DateOnly? Ngaynap { get; set; }

    public decimal Sotiennap { get; set; }

    public DateOnly? Ngayrut { get; set; }

    public decimal Sotienrut { get; set; }

    public decimal? Lailo { get; set; }
}
