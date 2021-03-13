using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MafiaAPI.Models
{
    public partial class MafiaDBContext : DbContext
    {
        public MafiaDBContext()
        {
        }

        public MafiaDBContext(DbContextOptions<MafiaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Boss> Bosses { get; set; }
        public virtual DbSet<FirstName> FirstNames { get; set; }
        public virtual DbSet<LastName> LastNames { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Mission> Missions { get; set; }
        public virtual DbSet<PerformingMission> PerformingMissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=MafiaDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Agent>(entity =>
            {
                entity.ToTable("Agent");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Boss)
                    .WithMany(p => p.Agents)
                    .HasForeignKey(d => d.BossId)
                    .HasConstraintName("FK__Agent__BossId__4BAC3F29");
            });

            modelBuilder.Entity<Boss>(entity =>
            {
                entity.ToTable("Boss");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastSeen).HasColumnType("datetime");
            });

            modelBuilder.Entity<FirstName>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FirstName1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FirstName");
            });

            modelBuilder.Entity<LastName>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.LastName1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LastName");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.Content)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("Content");

                entity.HasOne(d => d.Boss)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.BossId)
                    .HasConstraintName("FK__Messages__BossId__5FB337D6");
            });

            modelBuilder.Entity<Mission>(entity =>
            {
                entity.ToTable("Mission");

                entity.Property(e => e.MissionName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PerformingMission>(entity =>
            {
                entity.ToTable("PerformingMission");

                entity.Property(e => e.CompletionTime).HasColumnType("datetime");

                entity.HasOne(d => d.Agent)
                    .WithMany(p => p.PerformingMissions)
                    .HasForeignKey(d => d.AgentId)
                    .HasConstraintName("FK__Performin__Agent__5165187F");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.PerformingMissions)
                    .HasForeignKey(d => d.MissionId)
                    .HasConstraintName("FK__Performin__Missi__5070F446");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
