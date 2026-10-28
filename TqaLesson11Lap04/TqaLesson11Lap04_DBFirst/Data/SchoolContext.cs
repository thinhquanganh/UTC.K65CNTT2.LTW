using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TqaLesson11Lap04_DBFirst.Models;

namespace TqaLesson11Lap04_DBFirst.Data;

public partial class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Learner> Learners { get; set; }

    public virtual DbSet<Major> Majors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.Property(e => e.CourseId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Learner).WithMany(p => p.Enrollments).OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
