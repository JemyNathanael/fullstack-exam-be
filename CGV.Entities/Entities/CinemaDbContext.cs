using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CGV.Entities;

public partial class CinemaDbContext : DbContext
{
    public CinemaDbContext()
    {
    }

    public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auditorium> Auditoriums { get; set; }

    public virtual DbSet<AuditoriumPriceMapping> AuditoriumPriceMappings { get; set; }

    public virtual DbSet<AuditoriumType> AuditoriumTypes { get; set; }

    public virtual DbSet<Cast> Casts { get; set; }

    public virtual DbSet<CgvUser> CgvUsers { get; set; }

    public virtual DbSet<Cinema> Cinemas { get; set; }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Holiday> Holidays { get; set; }

    public virtual DbSet<InformationCategtory> InformationCategtories { get; set; }

    public virtual DbSet<MasterInformation> MasterInformations { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieCastMapping> MovieCastMappings { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<Snack> Snacks { get; set; }

    public virtual DbSet<SnackCategory> SnackCategories { get; set; }

    public virtual DbSet<TransactionHeader> TransactionHeaders { get; set; }

    public virtual DbSet<TransactionMovieDetail> TransactionMovieDetails { get; set; }

    public virtual DbSet<TransactionSnackDetail> TransactionSnackDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

   /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost; Database=cgv_clone_db; Username=postgres; Password=naeL0821;");*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Auditorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("auditoriums_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("'SYSTEM'::character varying");

            entity.HasOne(d => d.AuditoriumType).WithMany(p => p.Auditoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auditoriums_auditorium_type_id_fkey");

            entity.HasOne(d => d.Cinema).WithMany(p => p.Auditoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auditoriums_cinema_id_fkey");
        });

        modelBuilder.Entity<AuditoriumPriceMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("auditorium_price_mapping_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.IsFriday).HasDefaultValueSql("'0'::\"bit\"");
            entity.Property(e => e.IsHoliday).HasDefaultValueSql("'0'::\"bit\"");
            entity.Property(e => e.IsWeekdays).HasDefaultValueSql("'1'::\"bit\"");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("'SYSTEM'::character varying");

            entity.HasOne(d => d.Auditorium).WithMany(p => p.AuditoriumPriceMappings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auditorium_price_mapping_auditorium_id_fkey");
        });

        modelBuilder.Entity<AuditoriumType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("auditorium_types_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
        });

        modelBuilder.Entity<Cast>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("casts_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
        });

        modelBuilder.Entity<CgvUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cgv_user_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("'SYSTEM'::character varying");

            entity.HasOne(d => d.UserType).WithMany(p => p.CgvUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_usertype_user");
        });

        modelBuilder.Entity<Cinema>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cinemas_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("'SYSTEM'::character varying");

            entity.HasOne(d => d.Region).WithMany(p => p.Cinemas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cinemas_region_id_fkey");
        });

        modelBuilder.Entity<Director>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("directors_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("genres_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
        });

        modelBuilder.Entity<Holiday>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("holiday_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
        });

        modelBuilder.Entity<InformationCategtory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("information_categtories_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
        });

        modelBuilder.Entity<MasterInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("master_information_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("'SYSTEM'::character varying");

            entity.HasOne(d => d.Category).WithMany(p => p.MasterInformations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("master_information_category_id_fkey");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("movies_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("'SYSTEM'::character varying");

            entity.HasOne(d => d.Director).WithMany(p => p.Movies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("movies_director_id_fkey");

            entity.HasOne(d => d.Genre).WithMany(p => p.Movies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("movies_genre_id_fkey");
        });

        modelBuilder.Entity<MovieCastMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("movie_cast_mapping_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("'SYSTEM'::character varying");

            entity.HasOne(d => d.Cast).WithMany(p => p.MovieCastMappings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("movie_cast_mapping_cast_id_fkey");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieCastMappings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("movie_cast_mapping_movie_id_fkey");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("payment_methods_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("regions_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("schedules_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("'SYSTEM'::character varying");

            entity.HasOne(d => d.Auditorium).WithMany(p => p.Schedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedules_auditorium_id_fkey");

            entity.HasOne(d => d.Movie).WithMany(p => p.Schedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedules_movie_id_fkey");
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("seats_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("'SYSTEM'::character varying");

            entity.HasOne(d => d.Schedule).WithMany(p => p.Seats)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("seats_schedule_id_fkey");
        });

        modelBuilder.Entity<Snack>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("snacks_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
        });

        modelBuilder.Entity<SnackCategory>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
        });

        modelBuilder.Entity<TransactionHeader>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("transaction_headers_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("'SYSTEM'::character varying");

            entity.HasOne(d => d.Cinema).WithMany(p => p.TransactionHeaders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transaction_headers_cinema_id_fkey");

            entity.HasOne(d => d.Movie).WithMany(p => p.TransactionHeaders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transaction_headers_movie_id_fkey");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.TransactionHeaders).HasConstraintName("transaction_headers_payment_method_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.TransactionHeaders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transaction_headers_user_id_fkey");

            entity.HasOne(d => d.Voucher).WithMany(p => p.TransactionHeaders).HasConstraintName("transaction_headers_voucher_id_fkey");
        });

        modelBuilder.Entity<TransactionMovieDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("transaction_movie_details_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("'SYSTEM'::character varying");

            entity.HasOne(d => d.Header).WithMany(p => p.TransactionMovieDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transaction_movie_details_header_id_fkey");

            entity.HasOne(d => d.Seat).WithMany(p => p.TransactionMovieDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transaction_movie_details_seat_id_fkey");
        });

        modelBuilder.Entity<TransactionSnackDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("transaction_snack_details_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("'SYSTEM'::character varying");

            entity.HasOne(d => d.Header).WithMany(p => p.TransactionSnackDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transaction_snack_details_header_id_fkey");

            entity.HasOne(d => d.Snack).WithMany(p => p.TransactionSnackDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transaction_snack_details_snack_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_types_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("vouchers_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("'SYSTEM'::character varying");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
