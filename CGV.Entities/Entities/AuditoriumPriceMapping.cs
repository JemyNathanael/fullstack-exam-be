using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CGV.Entities;

[Table("auditorium_price_mapping")]
public partial class AuditoriumPriceMapping
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("auditorium_id")]
    public Guid AuditoriumId { get; set; }

    [Column("is_weekdays", TypeName = "bit(1)")]
    public BitArray IsWeekdays { get; set; } = null!;

    [Column("is_friday", TypeName = "bit(1)")]
    public BitArray IsFriday { get; set; } = null!;

    [Column("is_holiday", TypeName = "bit(1)")]
    public BitArray IsHoliday { get; set; } = null!;

    [Column("price")]
    public decimal Price { get; set; }

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

    [ForeignKey("AuditoriumId")]
    [InverseProperty("AuditoriumPriceMappings")]
    public virtual Auditorium Auditorium { get; set; } = null!;
}
