using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CGV.Entities;

[Table("vouchers")]
public partial class Voucher
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("description")]
    [StringLength(255)]
    public string Description { get; set; } = null!;

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    [StringLength(255)]
    public string CreatedBy { get; set; } = null!;

    [Column("updated_at", TypeName = "timestamp without time zone")]
    public DateTime UpdatedAt { get; set; }

    [Column("updated_by")]
    [StringLength(255)]
    public string UpdatedBy { get; set; } = null!;

    [InverseProperty("Voucher")]
    public virtual ICollection<TransactionHeader> TransactionHeaders { get; set; } = new List<TransactionHeader>();
}
