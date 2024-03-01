using System;
using System.Collections.Generic;
using AngularAppTest.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularAppTest.Server.Data;

public partial class EducationContext : DbContext
{
    public EducationContext()
    {
    }

    public EducationContext(DbContextOptions<EducationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<School> Schools { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data source=DESKTOP-Q2EIECU;Initial Catalog=education;Integrated Security=True;trusted_connection=true;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasOne(d => d.School).WithMany(p => p.Classrooms).HasConstraintName("FK_School");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasOne(d => d.Classroom).WithMany(p => p.Students).HasConstraintName("FK_Classroom_Student");

            entity.HasOne(d => d.School).WithMany(p => p.Students).HasConstraintName("FK_School_Student");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasOne(d => d.Classroom).WithMany(p => p.Teachers).HasConstraintName("FK_Classroom_Teacher");

            entity.HasOne(d => d.School).WithMany(p => p.Teachers).HasConstraintName("FK_School_Teacher");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
