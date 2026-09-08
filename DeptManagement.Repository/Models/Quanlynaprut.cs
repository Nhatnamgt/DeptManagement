using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DeptManagement.Repository.Models;

[Table("quanlynaprut")]
public partial class Quanlynaprut
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("ngaynap")]
    public DateOnly? Ngaynap { get; set; }

    [Column("sotiennap")]
    [Precision(18, 2)]
    public decimal Sotiennap { get; set; }

    [Column("ngayrut")]
    public DateOnly? Ngayrut { get; set; }

    [Column("sotienrut")]
    [Precision(18, 2)]
    public decimal Sotienrut { get; set; }

    [Column("lailo")]
    [Precision(18, 2)]
    public decimal? Lailo { get; set; }

    [Column("ghichu")]
    public string? Ghichu { get; set; }
}
