﻿// <auto-generated />
using System;
using MafiaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MafiaAPI.Migrations
{
    [DbContext(typeof(MafiaDBContext))]
    partial class MafiaDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Polish_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MafiaAPI.Models.Agent", b =>
                {
                    b.Property<int>("AgentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BossId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("Income")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("Strength")
                        .HasColumnType("int");

                    b.Property<string>("xD")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AgentId");

                    b.HasIndex("BossId");

                    b.ToTable("Agent");
                });

            modelBuilder.Entity("MafiaAPI.Models.Boss", b =>
                {
                    b.Property<int>("BossId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("LastSeen")
                        .HasColumnType("datetime");

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.HasKey("BossId");

                    b.ToTable("Boss");
                });

            modelBuilder.Entity("MafiaAPI.Models.FirstName", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.ToTable("FirstNames");
                });

            modelBuilder.Entity("MafiaAPI.Models.LastName", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.ToTable("LastNames");
                });

            modelBuilder.Entity("MafiaAPI.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BossId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)");

                    b.HasKey("MessageId");

                    b.HasIndex("BossId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("MafiaAPI.Models.Mission", b =>
                {
                    b.Property<int>("MissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DifficultyLevel")
                        .HasColumnType("int");

                    b.Property<int?>("Loot")
                        .HasColumnType("int");

                    b.Property<string>("MissionName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("MissionId");

                    b.ToTable("Mission");
                });

            modelBuilder.Entity("MafiaAPI.Models.PerformingMission", b =>
                {
                    b.Property<int>("PerformingMissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AgentId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CompletionTime")
                        .HasColumnType("datetime");

                    b.Property<int?>("MissionId")
                        .HasColumnType("int");

                    b.HasKey("PerformingMissionId");

                    b.HasIndex("AgentId");

                    b.HasIndex("MissionId");

                    b.ToTable("PerformingMission");
                });

            modelBuilder.Entity("MafiaAPI.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BossId")
                        .HasColumnType("int");

                    b.Property<string>("Nick")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("PlayerId");

                    b.HasIndex(new[] { "BossId" }, "UQ__Player__07C93FB72CC07189")
                        .IsUnique();

                    b.ToTable("Player");
                });

            modelBuilder.Entity("MafiaAPI.Models.Agent", b =>
                {
                    b.HasOne("MafiaAPI.Models.Boss", "Boss")
                        .WithMany("Agents")
                        .HasForeignKey("BossId")
                        .HasConstraintName("FK__Agent__BossId__4BAC3F29");

                    b.Navigation("Boss");
                });

            modelBuilder.Entity("MafiaAPI.Models.Message", b =>
                {
                    b.HasOne("MafiaAPI.Models.Boss", "Boss")
                        .WithMany("Messages")
                        .HasForeignKey("BossId")
                        .HasConstraintName("FK__Message__BossId__66603565");

                    b.Navigation("Boss");
                });

            modelBuilder.Entity("MafiaAPI.Models.PerformingMission", b =>
                {
                    b.HasOne("MafiaAPI.Models.Agent", "Agent")
                        .WithMany("PerformingMissions")
                        .HasForeignKey("AgentId")
                        .HasConstraintName("FK__Performin__Agent__5165187F");

                    b.HasOne("MafiaAPI.Models.Mission", "Mission")
                        .WithMany("PerformingMissions")
                        .HasForeignKey("MissionId")
                        .HasConstraintName("FK__Performin__Missi__5070F446");

                    b.Navigation("Agent");

                    b.Navigation("Mission");
                });

            modelBuilder.Entity("MafiaAPI.Models.Player", b =>
                {
                    b.HasOne("MafiaAPI.Models.Boss", "Boss")
                        .WithOne("Player")
                        .HasForeignKey("MafiaAPI.Models.Player", "BossId")
                        .HasConstraintName("FK__Player__BossId__1DB06A4F")
                        .IsRequired();

                    b.Navigation("Boss");
                });

            modelBuilder.Entity("MafiaAPI.Models.Agent", b =>
                {
                    b.Navigation("PerformingMissions");
                });

            modelBuilder.Entity("MafiaAPI.Models.Boss", b =>
                {
                    b.Navigation("Agents");

                    b.Navigation("Messages");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("MafiaAPI.Models.Mission", b =>
                {
                    b.Navigation("PerformingMissions");
                });
#pragma warning restore 612, 618
        }
    }
}
