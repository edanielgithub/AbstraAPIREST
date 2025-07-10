using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebMundo.Models;

public partial class DbMundoContext : DbContext
{
    public DbMundoContext()
    {
    }

    public DbMundoContext(DbContextOptions<DbMundoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

   /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-NC1A0RP\\MSSQLSERVER2016;Database=DB_MUNDO;Trusted_Connection=True;TrustServerCertificate=True;");
   */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.ToTable("CIUDAD");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FecAct)
                .HasColumnType("datetime")
                .HasColumnName("FEC_ACT");
            entity.Property(e => e.FecCreacion)
                .HasColumnType("datetime")
                .HasColumnName("FEC_CREACION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .HasColumnName("PAIS");
            entity.Property(e => e.Poblacion).HasColumnName("POBLACION");
            entity.Property(e => e.Superficie)
                .HasMaxLength(50)
                .HasColumnName("SUPERFICIE");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Usr).HasName("PK__USUARIO__C5B108E3E619DB6F");

            entity.ToTable("USUARIO");

            entity.Property(e => e.Usr)
                .HasMaxLength(50)
                .HasColumnName("USR");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .HasColumnName("APELLIDOS");
            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .HasColumnName("CLAVE");
            entity.Property(e => e.FecAct)
                .HasColumnType("datetime")
                .HasColumnName("FEC_ACT");
            entity.Property(e => e.FecCreacion)
                .HasColumnType("datetime")
                .HasColumnName("FEC_CREACION");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .HasColumnName("NOMBRES");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
