using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CGV.Entities;

[Table("transaction_movie_details")]
public partial class TransactionMovieDetail
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("header_id")]
    public Guid HeaderId { get; set; }

    [Column("seat_id")]
    public Guid SeatId { get; set; }

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

    [ForeignKey("HeaderId")]
    [InverseProperty("TransactionMovieDetails")]
    public virtual TransactionHeader Header { get; set; } = null!;

    [ForeignKey("SeatId")]
    [InverseProperty("TransactionMovieDetails")]
    public virtual Seat Seat { get; set; } = null!;
}
