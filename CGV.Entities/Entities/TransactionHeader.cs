using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CGV.Entities;

[Table("transaction_headers")]
public partial class TransactionHeader
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("payment_method_id")]
    public int? PaymentMethodId { get; set; }

    [Column("transaction_date", TypeName = "timestamp without time zone")]
    public DateTime TransactionDate { get; set; }

    [Column("cinema_id")]
    public Guid CinemaId { get; set; }

    [Column("show_date", TypeName = "timestamp without time zone")]
    public DateTime ShowDate { get; set; }

    [Column("movie_id")]
    public Guid MovieId { get; set; }

    [Column("voucher_id")]
    public Guid? VoucherId { get; set; }

    [Column("amount")]
    public decimal Amount { get; set; }

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

    [ForeignKey("CinemaId")]
    [InverseProperty("TransactionHeaders")]
    public virtual Cinema Cinema { get; set; } = null!;

    [ForeignKey("MovieId")]
    [InverseProperty("TransactionHeaders")]
    public virtual Movie Movie { get; set; } = null!;

    [ForeignKey("PaymentMethodId")]
    [InverseProperty("TransactionHeaders")]
    public virtual PaymentMethod? PaymentMethod { get; set; }

    [InverseProperty("Header")]
    public virtual ICollection<TransactionMovieDetail> TransactionMovieDetails { get; set; } = new List<TransactionMovieDetail>();

    [InverseProperty("Header")]
    public virtual ICollection<TransactionSnackDetail> TransactionSnackDetails { get; set; } = new List<TransactionSnackDetail>();

    [ForeignKey("UserId")]
    [InverseProperty("TransactionHeaders")]
    public virtual CgvUser User { get; set; } = null!;

    [ForeignKey("VoucherId")]
    [InverseProperty("TransactionHeaders")]
    public virtual Voucher? Voucher { get; set; }
}
