using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class EmisorPruebaContext : DbContext
{
    public EmisorPruebaContext()
    {
    }

    public EmisorPruebaContext(DbContextOptions<EmisorPruebaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Emisor> Emisors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=VICTOR-PC2\\SQLExpress;Database=EmisorPrueba;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Emisor>(entity =>
        {
            entity.HasKey(e => e.IdEmisor).HasName("PK__Emisor__134E2230B58C0B6E");

            entity.ToTable("Emisor");

            entity.Property(e => e.IdEmisor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idEmisor");
            entity.Property(e => e.Capital).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.FechaInicioOperacion).HasColumnType("datetime");
            entity.Property(e => e.Rfc)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
