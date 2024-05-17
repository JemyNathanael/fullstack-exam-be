using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CGV.Entities;

[Table("auditoriums")]
public partial class Auditorium
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("auditorium_type_id")]
    public Guid AuditoriumTypeId { get; set; }

    [Column("cinema_id")]
    public Guid CinemaId { get; set; }

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

    [InverseProperty("Auditorium")]
    public virtual ICollection<AuditoriumPriceMapping> AuditoriumPriceMappings { get; set; } = new List<AuditoriumPriceMapping>();

    [ForeignKey("AuditoriumTypeId")]
    [InverseProperty("Auditoria")]
    public virtual AuditoriumType AuditoriumType { get; set; } = null!;

    [ForeignKey("CinemaId")]
    [InverseProperty("Auditoria")]
    public virtual Cinema Cinema { get; set; } = null!;

    [InverseProperty("Auditorium")]
    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
