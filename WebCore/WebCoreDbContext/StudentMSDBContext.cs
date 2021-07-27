using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebCoreConstants;
using WebCoreEntities;

namespace WebCoreDbContext
{
    public partial class StudentMSContext : DbContext
    {
        public EnviuornmentValues EnviuornmentValues { get; set; }
        public StudentMSContext(EnviuornmentValues enviuornmentValues)
        {
            EnviuornmentValues= enviuornmentValues;
        }

        public StudentMSContext(DbContextOptions<StudentMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> StudentSet { get; set; }
        public virtual DbSet<Subject> SubjectSet { get; set; }

        public DbSet<LoginUserIdentity> LoginUserIdentitySet { get; set; }

        public DbSet<LoginUserClaimIdentity> LoginUserClaimIdentitySet { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
               optionsBuilder.UseSqlServer(EnviuornmentValues.ConnectionString);
                //azureabhayvelVn\SQLEXPRESS
              //  optionsBuilder.UseSqlServer("Data Source=DESKTOP-C0FBNF9\\SQLEXPRESS;Initial Catalog=StudentMS;Integrated Security=True");
              //  optionsBuilder.UseSqlServer("Data Source=azureabhayvelVn\\SQLEXPRESS;Initial Catalog=StudentMS;Integrated Security=True");

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
