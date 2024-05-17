using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CGV.Entities;

[Table("movie_cast_mapping")]
public partial class MovieCastMapping
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("movie_id")]
    public Guid MovieId { get; set; }

    [Column("cast_id")]
    public Guid CastId { get; set; }

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

    [ForeignKey("CastId")]
    [InverseProperty("MovieCastMappings")]
    public virtual Cast Cast { get; set; } = null!;

    [ForeignKey("MovieId")]
    [InverseProperty("MovieCastMappings")]
    public virtual Movie Movie { get; set; } = null!;
}
