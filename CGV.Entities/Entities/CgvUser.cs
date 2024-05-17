using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CGV.Entities;

[Table("cgv_user")]
[Index("Email", Name = "cgv_user_email_key", IsUnique = true)]
public partial class CgvUser
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("gender", TypeName = "bit(1)")]
    public BitArray Gender { get; set; } = null!;

    [Column("username")]
    [StringLength(255)]
    public string Username { get; set; } = null!;

    [Column("email")]
    [StringLength(255)]
    public string Email { get; set; } = null!;

    [Column("user_password")]
    [StringLength(255)]
    public string UserPassword { get; set; } = null!;

    [Column("address")]
    public string Address { get; set; } = null!;

    [Column("phone_number")]
    [StringLength(16)]
    public string? PhoneNumber { get; set; }

    [Column("credits")]
    public decimal? Credits { get; set; }

    [Column("points")]
    public decimal? Points { get; set; }

    [Column("user_type_id")]
    public int UserTypeId { get; set; }

    [Column("is_verified", TypeName = "bit(1)")]
    public BitArray IsVerified { get; set; } = null!;

    [Column("date_of_birth")]
    public DateOnly DateOfBirth { get; set; }

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

    [InverseProperty("User")]
    public virtual ICollection<TransactionHeader> TransactionHeaders { get; set; } = new List<TransactionHeader>();

    [ForeignKey("UserTypeId")]
    [InverseProperty("CgvUsers")]
    public virtual UserType UserType { get; set; } = null!;
}
