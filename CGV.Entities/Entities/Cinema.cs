using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CGV.Entities;

[Table("cinemas")]
public partial class Cinema
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("region_id")]
    public Guid RegionId { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("address")]
    public string Address { get; set; } = null!;

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

    [InverseProperty("Cinema")]
    public virtual ICollection<Auditorium> Auditoria { get; set; } = new List<Auditorium>();

    [ForeignKey("RegionId")]
    [InverseProperty("Cinemas")]
    public virtual Region Region { get; set; } = null!;

    [InverseProperty("Cinema")]
    public virtual ICollection<TransactionHeader> TransactionHeaders { get; set; } = new List<TransactionHeader>();
}
