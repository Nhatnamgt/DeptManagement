using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DeptManagement.Repository.Models;

[Table("chitietkhoanvay")]
public partial class Chitietkhoanvay
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("khoannoid")]
    public int Khoannoid { get; set; }

    [Column("ngayvay")]
    public DateOnly Ngayvay { get; set; }

    [Column("sotienvay")]
    [Precision(18, 2)]
    public decimal Sotienvay { get; set; }

    [Column("sotienlai")]
    [Precision(18, 2)]
    public decimal Sotienlai { get; set; }

    [Column("sotientramoiky")]
    [Precision(18, 2)]
    public decimal? Sotientramoiky { get; set; }

    [Column("songaytra")]
    public int? Songaytra { get; set; }

    [Column("tongtien")]
    [Precision(18, 2)]
    public decimal? Tongtien { get; set; }

    [Column("ghichu")]
    public string? Ghichu { get; set; }

    [ForeignKey("Khoannoid")]
    [InverseProperty("Chitietkhoanvays")]
    public virtual Quanlykhoanno Khoanno { get; set; } = null!;
}
