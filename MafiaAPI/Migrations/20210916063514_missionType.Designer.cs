﻿// <auto-generated />
using System;
using MafiaAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MafiaAPI.Migrations
{
    [DbContext(typeof(MafiaDBContext))]
    [Migration("20210916063514_missionType")]
    partial class missionType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Polish_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MafiaAPI.Models.Agent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("BossId")
                        .HasColumnType("bigint");

                    b.Property<int>("Dexterity")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("Income")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BossId");

                    b.ToTable("Agent");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BossId = 1L,
                            Dexterity = 10,
                            FirstName = "Jotaro",
                            Income = 100,
                            Intelligence = 10,
                            LastName = "Kujo",
                            Strength = 10
                        },
                        new
                        {
                            Id = 2L,
                            BossId = 1L,
                            Dexterity = 5,
                            FirstName = "Adam",
                            Income = 50,
                            Intelligence = 5,
                            LastName = "Mickiewicz",
                            Strength = 5
                        },
                        new
                        {
                            Id = 3L,
                            BossId = 2L,
                            Dexterity = 4,
                            FirstName = "Natalia",
                            Income = 70,
                            Intelligence = 3,
                            LastName = "Natsu",
                            Strength = 7
                        },
                        new
                        {
                            Id = 4L,
                            Dexterity = 7,
                            FirstName = "Eleonora",
                            Income = 30,
                            Intelligence = 0,
                            LastName = "Lora",
                            Strength = 8
                        },
                        new
                        {
                            Id = 5L,
                            BossId = 1L,
                            Dexterity = 1,
                            FirstName = "Robert",
                            Income = 200,
                            Intelligence = 5,
                            LastName = "Makłowicz",
                            Strength = 3
                        });
                });

            modelBuilder.Entity("MafiaAPI.Models.AgentForSale", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AgentId")
                        .HasColumnType("bigint");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AgentId")
                        .IsUnique();

                    b.ToTable("AgentForSale");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AgentId = 4L,
                            Price = 5000L
                        });
                });

            modelBuilder.Entity("MafiaAPI.Models.Boss", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
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

                    b.Property<long>("Money")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Boss");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            FirstName = "Patricio",
                            LastName = "Rico",
                            LastSeen = new DateTime(2021, 9, 16, 8, 35, 13, 414, DateTimeKind.Local).AddTicks(3812),
                            Money = 5000L
                        },
                        new
                        {
                            Id = 2L,
                            FirstName = "Rodrigo",
                            LastName = "Margherita",
                            LastSeen = new DateTime(2021, 9, 16, 8, 35, 13, 419, DateTimeKind.Local).AddTicks(9894),
                            Money = 5000L
                        });
                });

            modelBuilder.Entity("MafiaAPI.Models.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)");

                    b.Property<long?>("FromBossId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ReceivedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Seen")
                        .HasColumnType("bit");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ToBossId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FromBossId");

                    b.HasIndex("ToBossId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("MafiaAPI.Models.Mission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DexterityPercentage")
                        .HasColumnType("int");

                    b.Property<int>("DifficultyLevel")
                        .HasColumnType("int");

                    b.Property<double>("Duration")
                        .HasColumnType("float");

                    b.Property<int>("IntelligencePercentage")
                        .HasColumnType("int");

                    b.Property<int>("Loot")
                        .HasColumnType("int");

                    b.Property<long?>("MissionTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("StrengthPercentage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MissionTypeId");

                    b.ToTable("Mission");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DexterityPercentage = 0,
                            DifficultyLevel = 7,
                            Duration = 30.0,
                            IntelligencePercentage = 0,
                            Loot = 5000,
                            Name = "Bank robbery",
                            StrengthPercentage = 0
                        },
                        new
                        {
                            Id = 2L,
                            DexterityPercentage = 0,
                            DifficultyLevel = 9,
                            Duration = 60.0,
                            IntelligencePercentage = 0,
                            Loot = 10000,
                            Name = "Senator assassination",
                            StrengthPercentage = 0
                        },
                        new
                        {
                            Id = 3L,
                            DexterityPercentage = 0,
                            DifficultyLevel = 2,
                            Duration = 10.0,
                            IntelligencePercentage = 0,
                            Loot = 100,
                            Name = "Party",
                            StrengthPercentage = 0
                        },
                        new
                        {
                            Id = 4L,
                            DexterityPercentage = 0,
                            DifficultyLevel = 1,
                            Duration = 5.0,
                            IntelligencePercentage = 0,
                            Loot = 10,
                            Name = "Buy a coffee",
                            StrengthPercentage = 0
                        },
                        new
                        {
                            Id = 5L,
                            DexterityPercentage = 0,
                            DifficultyLevel = 5,
                            Duration = 55.0,
                            IntelligencePercentage = 0,
                            Loot = 5000,
                            Name = "Money laundering",
                            StrengthPercentage = 0
                        },
                        new
                        {
                            Id = 6L,
                            DexterityPercentage = 0,
                            DifficultyLevel = 6,
                            Duration = 3600.0,
                            IntelligencePercentage = 0,
                            Loot = 2000,
                            Name = "Car theft",
                            StrengthPercentage = 0
                        },
                        new
                        {
                            Id = 7L,
                            DexterityPercentage = 0,
                            DifficultyLevel = 8,
                            Duration = 15.0,
                            IntelligencePercentage = 0,
                            Loot = 7000,
                            Name = "Arms trade",
                            StrengthPercentage = 0
                        });
                });

            modelBuilder.Entity("MafiaAPI.Models.MissionType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DexterityPercentage")
                        .HasColumnType("int");

                    b.Property<double>("Duration")
                        .HasColumnType("float");

                    b.Property<int>("IntelligencePercentage")
                        .HasColumnType("int");

                    b.Property<int>("MaxDifficulty")
                        .HasColumnType("int");

                    b.Property<int>("MaxLoot")
                        .HasColumnType("int");

                    b.Property<int>("MinDifficulty")
                        .HasColumnType("int");

                    b.Property<int>("MinLoot")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StrengthPercentage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MissionType");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DexterityPercentage = 20,
                            Duration = 30.0,
                            IntelligencePercentage = 20,
                            MaxDifficulty = 6,
                            MaxLoot = 6000,
                            MinDifficulty = 4,
                            MinLoot = 4000,
                            Name = "Bank robbery",
                            StrengthPercentage = 60
                        },
                        new
                        {
                            Id = 2L,
                            DexterityPercentage = 10,
                            Duration = 60.0,
                            IntelligencePercentage = 10,
                            MaxDifficulty = 10,
                            MaxLoot = 10000,
                            MinDifficulty = 8,
                            MinLoot = 8000,
                            Name = "Senator assassination",
                            StrengthPercentage = 80
                        },
                        new
                        {
                            Id = 3L,
                            DexterityPercentage = 0,
                            Duration = 10.0,
                            IntelligencePercentage = 100,
                            MaxDifficulty = 3,
                            MaxLoot = 1000,
                            MinDifficulty = 1,
                            MinLoot = 100,
                            Name = "Party",
                            StrengthPercentage = 0
                        },
                        new
                        {
                            Id = 4L,
                            DexterityPercentage = 30,
                            Duration = 5.0,
                            IntelligencePercentage = 40,
                            MaxDifficulty = 1,
                            MaxLoot = 100,
                            MinDifficulty = 1,
                            MinLoot = 100,
                            Name = "Buy a coffee",
                            StrengthPercentage = 30
                        },
                        new
                        {
                            Id = 5L,
                            DexterityPercentage = 20,
                            Duration = 55.0,
                            IntelligencePercentage = 60,
                            MaxDifficulty = 6,
                            MaxLoot = 6000,
                            MinDifficulty = 4,
                            MinLoot = 4000,
                            Name = "Money laundering",
                            StrengthPercentage = 20
                        },
                        new
                        {
                            Id = 6L,
                            DexterityPercentage = 80,
                            Duration = 3600.0,
                            IntelligencePercentage = 10,
                            MaxDifficulty = 6,
                            MaxLoot = 6000,
                            MinDifficulty = 4,
                            MinLoot = 4000,
                            Name = "Car theft",
                            StrengthPercentage = 10
                        },
                        new
                        {
                            Id = 7L,
                            DexterityPercentage = 10,
                            Duration = 15.0,
                            IntelligencePercentage = 80,
                            MaxDifficulty = 8,
                            MaxLoot = 8000,
                            MinDifficulty = 6,
                            MinLoot = 6000,
                            Name = "Arms trade",
                            StrengthPercentage = 10
                        });
                });

            modelBuilder.Entity("MafiaAPI.Models.PerformingMission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AgentId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CompletionTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("MissionId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("MissionId");

                    b.ToTable("PerformingMission");
                });

            modelBuilder.Entity("MafiaAPI.Models.Player", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BossId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nick")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "BossId" }, "UQ__Player__07C93FB72CC07189")
                        .IsUnique();

                    b.ToTable("Player");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BossId = 1L,
                            Nick = "mafia",
                            Password = "tlnK6HiwFF4+b4DRVaVdRlIPtzduirsf8W3+nbXlLWlf9c/J"
                        },
                        new
                        {
                            Id = 2L,
                            BossId = 2L,
                            Nick = "tomek",
                            Password = "d2JZt0Jz9UzgW1l544W2WnOaX14u/pfGUDYTQzv5AEWk3W7D"
                        });
                });

            modelBuilder.Entity("MafiaAPI.Models.Report", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)");

                    b.Property<DateTime>("ReceivedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Seen")
                        .HasColumnType("bit");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ToBossId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ToBossId");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("MafiaAPI.Models.Agent", b =>
                {
                    b.HasOne("MafiaAPI.Models.Boss", "Boss")
                        .WithMany("Agents")
                        .HasForeignKey("BossId")
                        .HasConstraintName("FK__Agent__BossId__4BAC3F29");

                    b.Navigation("Boss");
                });

            modelBuilder.Entity("MafiaAPI.Models.AgentForSale", b =>
                {
                    b.HasOne("MafiaAPI.Models.Agent", "Agent")
                        .WithOne("AgentForSale")
                        .HasForeignKey("MafiaAPI.Models.AgentForSale", "AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");
                });

            modelBuilder.Entity("MafiaAPI.Models.Message", b =>
                {
                    b.HasOne("MafiaAPI.Models.Boss", "FromBoss")
                        .WithMany("MessageFromBosses")
                        .HasForeignKey("FromBossId")
                        .HasConstraintName("FK__Message__FromBos__2180FB33");

                    b.HasOne("MafiaAPI.Models.Boss", "ToBoss")
                        .WithMany("MessageToBosses")
                        .HasForeignKey("ToBossId")
                        .HasConstraintName("FK__Message__ToBossI__208CD6FA");

                    b.Navigation("FromBoss");

                    b.Navigation("ToBoss");
                });

            modelBuilder.Entity("MafiaAPI.Models.Mission", b =>
                {
                    b.HasOne("MafiaAPI.Models.MissionType", null)
                        .WithMany("Missions")
                        .HasForeignKey("MissionTypeId");
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

            modelBuilder.Entity("MafiaAPI.Models.Report", b =>
                {
                    b.HasOne("MafiaAPI.Models.Boss", "ToBoss")
                        .WithMany("ReportToBosses")
                        .HasForeignKey("ToBossId")
                        .HasConstraintName("FK__Report__ToBossI__208CD6FC");

                    b.Navigation("ToBoss");
                });

            modelBuilder.Entity("MafiaAPI.Models.Agent", b =>
                {
                    b.Navigation("AgentForSale");

                    b.Navigation("PerformingMissions");
                });

            modelBuilder.Entity("MafiaAPI.Models.Boss", b =>
                {
                    b.Navigation("Agents");

                    b.Navigation("MessageFromBosses");

                    b.Navigation("MessageToBosses");

                    b.Navigation("Player");

                    b.Navigation("ReportToBosses");
                });

            modelBuilder.Entity("MafiaAPI.Models.Mission", b =>
                {
                    b.Navigation("PerformingMissions");
                });

            modelBuilder.Entity("MafiaAPI.Models.MissionType", b =>
                {
                    b.Navigation("Missions");
                });
#pragma warning restore 612, 618
        }
    }
}
