using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DeptManagement.Repository.Models;

[Table("quanlykhoanno")]
public partial class Quanlykhoanno
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("tenkhoanno")]
    [StringLength(255)]
    public string Tenkhoanno { get; set; } = null!;

    [Column("nguoichovay")]
    [StringLength(255)]
    public string? Nguoichovay { get; set; }

    [Column("ghichu")]
    public string? Ghichu { get; set; }

    [InverseProperty("Khoanno")]
    public virtual ICollection<Chitietkhoanvay> Chitietkhoanvays { get; set; } = new List<Chitietkhoanvay>();
}
