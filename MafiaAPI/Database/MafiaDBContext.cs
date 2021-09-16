using System;
using Microsoft.EntityFrameworkCore;
using MafiaAPI.Models;
using Microsoft.Extensions.Logging;
#nullable disable

namespace MafiaAPI.Database
{
    public partial class MafiaDBContext : DbContext
    {

        public static readonly ILoggerFactory MyLoggerFactory
    = LoggerFactory.Create(builder => { builder.AddConsole(); }); 
        public MafiaDBContext() { }

        public MafiaDBContext(DbContextOptions<MafiaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Boss> Bosses { get; set; }

        internal object Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Mission> Missions { get; set; }
        public virtual DbSet<MissionType> MissionTypes { get; set; }
        public virtual DbSet<PerformingMission> PerformingMissions { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<AgentForSale> AgentsForSale { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLoggerFactory(MyLoggerFactory)
                    .EnableSensitiveDataLogging()
                    .UseSqlServer(Environment.GetEnvironmentVariable("MafiaAppCon"));
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


            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.Content)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.FromBoss)
                    .WithMany(p => p.MessageFromBosses)
                    .HasForeignKey(d => d.FromBossId)
                    .HasConstraintName("FK__Message__FromBos__2180FB33");

                entity.HasOne(d => d.ToBoss)
                    .WithMany(p => p.MessageToBosses)
                    .HasForeignKey(d => d.ToBossId)
                    .HasConstraintName("FK__Message__ToBossI__208CD6FA");
            });


            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("Report");

                entity.Property(e => e.Content)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.ToBoss)
                    .WithMany(p => p.ReportToBosses)
                    .HasForeignKey(d => d.ToBossId)
                    .HasConstraintName("FK__Report__ToBossI__208CD6FC");
            });

            modelBuilder.Entity<Mission>(entity =>
            {
                entity.ToTable("Mission");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MissionType>(entity =>
            {
                entity.ToTable("MissionType");
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

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");

                entity.HasIndex(e => e.BossId, "UQ__Player__07C93FB72CC07189")
                    .IsUnique();

                entity.Property(e => e.Nick)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Boss)
                    .WithOne(p => p.Player)
                    .HasForeignKey<Player>(d => d.BossId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Player__BossId__1DB06A4F");
            });

            modelBuilder.Entity<AgentForSale>(entity =>
            {
                entity.ToTable("AgentForSale");

                entity.HasOne(d => d.Agent)
                .WithOne(x => x.AgentForSale )
                .HasForeignKey<AgentForSale>(x => x.AgentId);
            });

            modelBuilder.Seed();
            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
