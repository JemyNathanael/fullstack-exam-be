using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CGV.Entities;

[Table("schedules")]
public partial class Schedule
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("show_time")]
    public DateOnly ShowTime { get; set; }

    [Column("movie_id")]
    public Guid MovieId { get; set; }

    [Column("auditorium_id")]
    public Guid AuditoriumId { get; set; }

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
    [InverseProperty("Schedules")]
    public virtual Auditorium Auditorium { get; set; } = null!;

    [ForeignKey("MovieId")]
    [InverseProperty("Schedules")]
    public virtual Movie Movie { get; set; } = null!;

    [InverseProperty("Schedule")]
    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
}
