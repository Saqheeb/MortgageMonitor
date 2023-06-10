using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MortgageMoniteringSystem.Models;

public partial class RiskManagerContext : DbContext
{
    public RiskManagerContext()
    {
    }

    public RiskManagerContext(DbContextOptions<RiskManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Register> Registers { get; set; }

    public virtual DbSet<RiskManager> RiskManagers { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.; Database=RiskManager; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Register>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Register__3214EC07FD4C9CB4");

            entity.ToTable("Register");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Access)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('allow')");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RiskManager>(entity =>
        {
            entity.HasKey(e => e.RiskManagerId).HasName("PK__RiskMana__60D4CB4720A26E76");

            entity.Property(e => e.RiskManagerId).ValueGeneratedNever();
            entity.Property(e => e.RiskManagerAccess)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.RiskManagerMail)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RiskManagerName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RiskManagerPassword)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Ticket__712CC607693654DF");

            entity.ToTable("Ticket");

            entity.Property(e => e.TicketId).ValueGeneratedNever();
            entity.Property(e => e.Content)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.Response)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.TicketDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
