using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CGV.Entities;

[Table("movies")]
public partial class Movie
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("title")]
    [StringLength(255)]
    public string Title { get; set; } = null!;

    [Column("director_id")]
    public Guid DirectorId { get; set; }

    [Column("censor_rating")]
    [StringLength(16)]
    public string CensorRating { get; set; } = null!;

    [Column("genre_id")]
    public Guid GenreId { get; set; }

    [Column("language")]
    [StringLength(255)]
    public string Language { get; set; } = null!;

    [Column("subtitle")]
    [StringLength(255)]
    public string Subtitle { get; set; } = null!;

    [Column("duration")]
    public int Duration { get; set; }

    [Column("synopsys", TypeName = "character varying")]
    public string Synopsys { get; set; } = null!;

    [Column("poster_url", TypeName = "character varying")]
    public string PosterUrl { get; set; } = null!;

    [Column("trailer_url", TypeName = "character varying")]
    public string TrailerUrl { get; set; } = null!;

    [Column("is_showing", TypeName = "bit(1)")]
    public BitArray IsShowing { get; set; } = null!;

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

    [ForeignKey("DirectorId")]
    [InverseProperty("Movies")]
    public virtual Director Director { get; set; } = null!;

    [ForeignKey("GenreId")]
    [InverseProperty("Movies")]
    public virtual Genre Genre { get; set; } = null!;

    [InverseProperty("Movie")]
    public virtual ICollection<MovieCastMapping> MovieCastMappings { get; set; } = new List<MovieCastMapping>();

    [InverseProperty("Movie")]
    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    [InverseProperty("Movie")]
    public virtual ICollection<TransactionHeader> TransactionHeaders { get; set; } = new List<TransactionHeader>();
}
