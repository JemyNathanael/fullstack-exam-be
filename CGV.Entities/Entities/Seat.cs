using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CGV.Entities;

[Table("seats")]
public partial class Seat
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("schedule_id")]
    public Guid ScheduleId { get; set; }

    [Column("seat_number")]
    [StringLength(8)]
    public string SeatNumber { get; set; } = null!;

    [Column("is_available", TypeName = "bit(1)")]
    public BitArray IsAvailable { get; set; } = null!;

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

    [ForeignKey("ScheduleId")]
    [InverseProperty("Seats")]
    public virtual Schedule Schedule { get; set; } = null!;

    [InverseProperty("Seat")]
    public virtual ICollection<TransactionMovieDetail> TransactionMovieDetails { get; set; } = new List<TransactionMovieDetail>();
}
