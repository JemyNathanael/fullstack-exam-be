using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CGV.Entities;

[Table("transaction_snack_details")]
public partial class TransactionSnackDetail
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("header_id")]
    public Guid HeaderId { get; set; }

    [Column("snack_id")]
    public Guid SnackId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

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
    [InverseProperty("TransactionSnackDetails")]
    public virtual TransactionHeader Header { get; set; } = null!;

    [ForeignKey("SnackId")]
    [InverseProperty("TransactionSnackDetails")]
    public virtual Snack Snack { get; set; } = null!;
}
