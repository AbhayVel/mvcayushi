using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebCoreEntities;

namespace WebCoreDbContext
{
    public partial class StudentMSContext : DbContext
    {
        public StudentMSContext()
        {
        }

        public StudentMSContext(DbContextOptions<StudentMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> StudentSet { get; set; }
        public virtual DbSet<Subject> SubjectSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=DESKTOP-C0FBNF9\\SQLEXPRESS;Initial Catalog=StudentMS;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Age).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Fees)
                    .HasColumnName("fees")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_TblStudent_TblSubject");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


}
