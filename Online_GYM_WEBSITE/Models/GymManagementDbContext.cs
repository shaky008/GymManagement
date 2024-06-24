using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Online_GYM_WEBSITE.Models;

public partial class GymManagementDbContext : DbContext
{
    public GymManagementDbContext()
    {
       
    }

  

    public GymManagementDbContext(DbContextOptions<GymManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GymMembership> GymMemberships { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=gym_management_db;Username=postgres;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GymMembership>(entity =>
        {
            entity.HasKey(e => e.GymMembershipId).HasName("gym_membership_pkey");

            entity.ToTable("gym_membership", "movie_schema");

            entity.Property(e => e.GymMembershipId).HasColumnName("gym_membership_id");
            entity.Property(e => e.MembershipCost).HasColumnName("membership_cost");
            entity.Property(e => e.MembershipDetail)
                .HasColumnType("character varying")
                .HasColumnName("membership_detail");
            entity.Property(e => e.MembershipLength).HasColumnName("membership_length");
            entity.Property(e => e.MembershipType)
                .HasColumnType("character varying")
                .HasColumnName("membership_type");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("order_detail_pkey");

            entity.ToTable("order_detail", "movie_schema");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.GymMembershipId).HasColumnName("gym_membership_id");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchase_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.GymMembership).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.GymMembershipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("gym_membership_id");

            entity.HasOne(d => d.User).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_id");
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("user_detail_pkey");

            entity.ToTable("user_detail", "movie_schema");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(64)
                .HasColumnName("user_email");
            entity.Property(e => e.UserName)
                .HasMaxLength(64)
                .HasColumnName("user_name");
            entity.Property(e => e.UserNumber).HasColumnName("user_number");
            entity.Property(e => e.UserType)
                .HasColumnType("character varying")
                .HasColumnName("user_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
